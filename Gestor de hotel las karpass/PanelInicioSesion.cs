using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_hotel_las_karpass
{
    public partial class PanelInicioSesion : Form
    {
        private ConexionBD conexionBD;

        public PanelInicioSesion()
        {
            InitializeComponent();

            TxCuenta.Text = "Cuenta";
            TxContrasena.Text = "Contraseña";
            TxContrasena.PasswordChar = '\0'; 
        }

        private void PanelInicioSesion_Load(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();

            conexion.abrir();
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

        private void TxCuenta_Enter(object sender, EventArgs e)
        {
            if (TxCuenta.Text == "Cuenta")
            {
                TxCuenta.Text = "";
            }
        }
        private void TxCuenta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxCuenta.Text))
            {
                TxCuenta.Text = "Cuenta";
            }
        }

        private void TxContrasena_Enter(object sender, EventArgs e)
        {
            if (TxContrasena.Text == "Contraseña")
            {
                TxContrasena.Text = "";
                TxContrasena.PasswordChar = '*';
            }
        }
        private void TxContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxContrasena.Text))
            {
                TxContrasena.Text = "Contraseña";
                TxContrasena.PasswordChar = '\0'; 
            }
        }

    }
}
