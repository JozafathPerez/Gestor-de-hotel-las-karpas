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
    public partial class PanelInicioSesion : Form
    {
        public PanelInicioSesion()
        {
            InitializeComponent();
        }

        private void BtInicioSesion_Click(object sender, EventArgs e)
        {
            // Oculta el formulario actual
            this.Hide();

            // Crea una instancia del formulario "PanelPrincipal"
            PanelPrincipal formularioSecundario = new PanelPrincipal();

            // Muestra el formulario secundario
            formularioSecundario.Show();
        }
    }
}
