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
            // Limpiar cualquier control existente en el PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Clear();

            string mensaje = "Botón seleccionado: Cliente";
            // Crear un nuevo control de texto con el mensaje
            Label mensajeLabel = new Label();
            mensajeLabel.Text = mensaje;
            mensajeLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            mensajeLabel.AutoSize = true;
            mensajeLabel.Location = new Point(20, 20);

            // Agregar el mensaje al PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Add(mensajeLabel);
        }

        private void BtReservas_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReservas);
            // Limpiar cualquier control existente en el PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Clear();

            string mensaje = "Botón seleccionado: Reservas";
            // Crear un nuevo control de texto con el mensaje
            Label mensajeLabel = new Label();
            mensajeLabel.Text = mensaje;
            mensajeLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            mensajeLabel.AutoSize = true;
            mensajeLabel.Location = new Point(20, 20);

            // Agregar el mensaje al PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Add(mensajeLabel);
        }

        private void BtReportería_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReportería);
            // Limpiar cualquier control existente en el PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Clear();

            string mensaje = "Botón seleccionado: Reportería";
            // Crear un nuevo control de texto con el mensaje
            Label mensajeLabel = new Label();
            mensajeLabel.Text = mensaje;
            mensajeLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            mensajeLabel.AutoSize = true;
            mensajeLabel.Location = new Point(20, 20);

            // Agregar el mensaje al PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Add(mensajeLabel);
        }

        private void BtPersonal_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtPersonal);
            // Limpiar cualquier control existente en el PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Clear();

            string mensaje = "Botón seleccionado: Personal";
            // Crear un nuevo control de texto con el mensaje
            Label mensajeLabel = new Label();
            mensajeLabel.Text = mensaje;
            mensajeLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            mensajeLabel.AutoSize = true;
            mensajeLabel.Location = new Point(20, 20);

            // Agregar el mensaje al PanelAreaDeTrabajo
            PanelAreaDeTrabajo.Controls.Add(mensajeLabel);
        }
    }
}
