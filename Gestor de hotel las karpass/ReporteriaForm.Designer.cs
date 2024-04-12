namespace Gestor_de_hotel_las_karpass
{
    partial class ReporteriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteriaForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.ImagenMenu = new System.Windows.Forms.PictureBox();
            this.BtReservas = new System.Windows.Forms.Button();
            this.btCancelaciones = new System.Windows.Forms.Button();
            this.btClientesRe = new System.Windows.Forms.Button();
            this.btRecepcionista = new System.Windows.Forms.Button();
            this.btFechasRe = new System.Windows.Forms.Button();
            this.btIngresos = new System.Windows.Forms.Button();
            this.btClienteFre = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagenMenu
            // 
            this.ImagenMenu.Image = ((System.Drawing.Image)(resources.GetObject("ImagenMenu.Image")));
            this.ImagenMenu.Location = new System.Drawing.Point(-3, 0);
            this.ImagenMenu.Name = "ImagenMenu";
            this.ImagenMenu.Size = new System.Drawing.Size(229, 514);
            this.ImagenMenu.TabIndex = 1;
            this.ImagenMenu.TabStop = false;
            // 
            // BtReservas
            // 
            this.BtReservas.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtReservas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtReservas.Location = new System.Drawing.Point(12, 211);
            this.BtReservas.Name = "BtReservas";
            this.BtReservas.Size = new System.Drawing.Size(204, 30);
            this.BtReservas.TabIndex = 2;
            this.BtReservas.Text = "Ver Reservas";
            this.BtReservas.UseVisualStyleBackColor = false;
            this.BtReservas.Click += new System.EventHandler(this.BtReservas_Click);
            // 
            // btCancelaciones
            // 
            this.btCancelaciones.BackColor = System.Drawing.Color.PapayaWhip;
            this.btCancelaciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btCancelaciones.Location = new System.Drawing.Point(12, 247);
            this.btCancelaciones.Name = "btCancelaciones";
            this.btCancelaciones.Size = new System.Drawing.Size(204, 30);
            this.btCancelaciones.TabIndex = 3;
            this.btCancelaciones.Text = "Ver Cancelaciones";
            this.btCancelaciones.UseVisualStyleBackColor = false;
            this.btCancelaciones.Click += new System.EventHandler(this.btCancelaciones_Click);
            // 
            // btClientesRe
            // 
            this.btClientesRe.BackColor = System.Drawing.Color.PapayaWhip;
            this.btClientesRe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btClientesRe.Location = new System.Drawing.Point(12, 283);
            this.btClientesRe.Name = "btClientesRe";
            this.btClientesRe.Size = new System.Drawing.Size(204, 30);
            this.btClientesRe.TabIndex = 4;
            this.btClientesRe.Text = "Ver Clientes x Residencia";
            this.btClientesRe.UseVisualStyleBackColor = false;
            this.btClientesRe.Click += new System.EventHandler(this.btClientesRe_Click);
            // 
            // btRecepcionista
            // 
            this.btRecepcionista.BackColor = System.Drawing.Color.PapayaWhip;
            this.btRecepcionista.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btRecepcionista.Location = new System.Drawing.Point(12, 319);
            this.btRecepcionista.Name = "btRecepcionista";
            this.btRecepcionista.Size = new System.Drawing.Size(204, 60);
            this.btRecepcionista.TabIndex = 5;
            this.btRecepcionista.Text = "Ver Recepcionista con Mas Reservas";
            this.btRecepcionista.UseVisualStyleBackColor = false;
            this.btRecepcionista.Click += new System.EventHandler(this.btRecepcionista_Click);
            // 
            // btFechasRe
            // 
            this.btFechasRe.BackColor = System.Drawing.Color.PapayaWhip;
            this.btFechasRe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btFechasRe.Location = new System.Drawing.Point(12, 385);
            this.btFechasRe.Name = "btFechasRe";
            this.btFechasRe.Size = new System.Drawing.Size(204, 30);
            this.btFechasRe.TabIndex = 6;
            this.btFechasRe.Text = "Ver Top Fechas x Reservas";
            this.btFechasRe.UseVisualStyleBackColor = false;
            this.btFechasRe.Click += new System.EventHandler(this.btFechasRe_Click);
            // 
            // btIngresos
            // 
            this.btIngresos.BackColor = System.Drawing.Color.PapayaWhip;
            this.btIngresos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btIngresos.Location = new System.Drawing.Point(12, 421);
            this.btIngresos.Name = "btIngresos";
            this.btIngresos.Size = new System.Drawing.Size(204, 30);
            this.btIngresos.TabIndex = 7;
            this.btIngresos.Text = "Ver Ingresos x Fechas";
            this.btIngresos.UseVisualStyleBackColor = false;
            this.btIngresos.Click += new System.EventHandler(this.btIngresos_Click);
            // 
            // btClienteFre
            // 
            this.btClienteFre.BackColor = System.Drawing.Color.PapayaWhip;
            this.btClienteFre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btClienteFre.Location = new System.Drawing.Point(12, 457);
            this.btClienteFre.Name = "btClienteFre";
            this.btClienteFre.Size = new System.Drawing.Size(204, 30);
            this.btClienteFre.TabIndex = 8;
            this.btClienteFre.Text = "Ver Cliente mas Frecuente";
            this.btClienteFre.UseVisualStyleBackColor = false;
            this.btClienteFre.Click += new System.EventHandler(this.btClienteFre_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(266, 34);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(496, 438);
            this.grid.TabIndex = 9;
            // 
            // grafico
            // 
            chartArea3.Name = "ChartArea1";
            this.grafico.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grafico.Legends.Add(legend3);
            this.grafico.Location = new System.Drawing.Point(266, 34);
            this.grafico.Name = "grafico";
            this.grafico.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.grafico.Size = new System.Drawing.Size(496, 438);
            this.grafico.TabIndex = 10;
            this.grafico.Text = "chart1";
            // 
            // ReporteriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 506);
            this.Controls.Add(this.grafico);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btClienteFre);
            this.Controls.Add(this.btIngresos);
            this.Controls.Add(this.btFechasRe);
            this.Controls.Add(this.btRecepcionista);
            this.Controls.Add(this.btClientesRe);
            this.Controls.Add(this.btCancelaciones);
            this.Controls.Add(this.BtReservas);
            this.Controls.Add(this.ImagenMenu);
            this.Name = "ReporteriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteriaForm";
            this.Load += new System.EventHandler(this.ReporteriaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagenMenu;
        private System.Windows.Forms.Button BtReservas;
        private System.Windows.Forms.Button btCancelaciones;
        private System.Windows.Forms.Button btClientesRe;
        private System.Windows.Forms.Button btRecepcionista;
        private System.Windows.Forms.Button btFechasRe;
        private System.Windows.Forms.Button btIngresos;
        private System.Windows.Forms.Button btClienteFre;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}