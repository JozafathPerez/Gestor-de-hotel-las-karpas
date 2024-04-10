using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_hotel_las_karpass
{
    public partial class PanelPrincipal : Form
    {
        // Variable para almacenar el último botón presionado
        private Button ultimoBoton = null;

        public PanelPrincipal()
        {
            InitializeComponent();
        }

        // Función para cambiar el color del botón y restaurar el color del último botón presionado
        private void CambiarColorBoton(Button botonPresionado)
        {
            if (ultimoBoton != null)
            {
                ultimoBoton.BackColor = Color.PapayaWhip; // Restaurar color del último botón
            }

            botonPresionado.BackColor = Color.Orange; // Cambiar color del botón presionado
            ultimoBoton = botonPresionado; // Actualizar el último botón presionado
        }

        private void BtCliente_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtCliente);

            cargarForm(new ClientesForm());
        }

        private void BtReservas_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReservas);

            cargarForm(new ReservasForm());
        }

        private void BtReportería_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReportería);

            cargarForm(new ReporteriaForm());
        }

        private void BtPersonal_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtPersonal);
            
            cargarForm(new PersonalForm());
        }

        public void cargarForm(object Form)
        {
            if (this.PanelAreaDeTrabajo.Controls.Count > 0)
                this.PanelAreaDeTrabajo.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.PanelAreaDeTrabajo.Controls.Add(f);
            this.PanelAreaDeTrabajo.Tag = f;
            f.Show();
        }
    }
}
