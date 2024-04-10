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
        private ConexionBD conexion;

        public PanelInicioSesion()
        {
            InitializeComponent();

            // Inicializar el objeto ConexionBD
            conexion = new ConexionBD();
        }

        private void PanelInicioSesion_Load(object sender, EventArgs e)
        {
            TxCuenta.Text = "Cuenta";
            TxContrasena.Text = "Contraseña";
            TxContrasena.PasswordChar = '\0';
        }

        private void BtInicioSesion_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña ingresados por el usuario
            string nombreUsuario = TxCuenta.Text;
            string contrasena = TxContrasena.Text;

            // Verificar las credenciales en la base de datos
            bool credencialesValidas = VerificarCredenciales(nombreUsuario, contrasena);

            if (credencialesValidas)
            {
                // Oculta el formulario actual
                this.Hide();

                // Crea una instancia del formulario "PanelPrincipal"
                PanelPrincipal formularioSecundario = new PanelPrincipal();

                // Muestra el formulario secundario
                formularioSecundario.Show();
            }
            else
            {
                // Mostrar ventana emergente de error
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarCredenciales(string nombreUsuario, string contrasena)
        {
            string query = "SELECT COUNT(*) FROM Empleados WHERE nombre = @nombreUsuario AND contrasena = @contrasena";

            SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
            command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            command.Parameters.AddWithValue("@contrasena", contrasena);

            try
            {
                conexion.abrir();
                int count = (int)command.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                // Si count es mayor que 0, las credenciales son válidas
                return count > 0;
            }
            catch 
            {
                return false;
            }
            finally
            {
                conexion.cerrar();
            }
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
