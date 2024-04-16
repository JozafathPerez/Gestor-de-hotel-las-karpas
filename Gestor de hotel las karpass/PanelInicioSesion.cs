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

        /*******************************************************
        * Nombre: PanelInicioSesion
        * Descripcion: almacena un objeto de tipo ConexionBD y inicializa la ventana.
        * Entradas: 
        * Salidad: 
        * *******************************************************/
        public PanelInicioSesion()
        {
            InitializeComponent();

            // Inicializar el objeto ConexionBD
            conexion = new ConexionBD();
        }

        /*******************************************************
        * Nombre: PanelInicioSesion_Load
        * Descripcion: Actualiza el texto de dos elementos de la ventana.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void PanelInicioSesion_Load(object sender, EventArgs e)
        {
            TxCorreo.Text = "Correo";
            TxContrasena.Text = "Contraseña";
            TxContrasena.PasswordChar = '\0';
        }

        /*******************************************************
        * Nombre: BtInicioSesion_Click
        * Descripcion: Da o denega el acceso del usuario al panel principal.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void BtInicioSesion_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña ingresados por el usuario
            string CorreoUsuario = TxCorreo.Text;
            string contrasena = TxContrasena.Text;

            // Verificar las credenciales en la base de datos
            bool credencialesValidas = VerificarCredenciales(CorreoUsuario, contrasena);

            if (credencialesValidas)
            {
                // Oculta el formulario actual
                this.Hide();

                conexion.abrir();
                string query = "SELECT idEmpleado FROM Empleados WHERE Correo = @CorreoUsuario AND contrasena = @contrasena";

                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                command.Parameters.AddWithValue("@CorreoUsuario", CorreoUsuario);
                command.Parameters.AddWithValue("@contrasena", contrasena);

                int idEmpleado = (int)command.ExecuteScalar();
                conexion.cerrar();

                // Crea una instancia del formulario "PanelPrincipal"
                PanelPrincipal formularioSecundario = new PanelPrincipal(idEmpleado);

                // Muestra el formulario secundario
                formularioSecundario.Show();
            }
            else
            {
                // Mostrar ventana emergente de error
                MessageBox.Show("Correo o contraseña incorrectos. Inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /*******************************************************
       * Nombre: VerificarCredenciales
       * Descripcion: Función para verificar las credenciales del usuario en la base de datos.
       * Entradas: objeto (object) en el cual se va realizar el evento 
       * y el evento a realizar en el (EventArgs).
       * Salidad: 
       * *******************************************************/
        private bool VerificarCredenciales(string CorreoUsuario, string contrasena)
        {
            string query = "SELECT COUNT(*) FROM Empleados WHERE Correo = @CorreoUsuario AND contrasena = @contrasena";

            SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
            command.Parameters.AddWithValue("@CorreoUsuario", CorreoUsuario);
            command.Parameters.AddWithValue("@contrasena", contrasena);

            try
            {
                conexion.abrir();
                int count = (int)command.ExecuteScalar(); 

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

        /*******************************************************
        * Nombre: TxCuenta_Enter
        * Descripcion: Actualiza el texto de un elemento de la ventana.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void TxCuenta_Enter(object sender, EventArgs e)
        {
            if (TxCorreo.Text == "Correo")
            {
                TxCorreo.Text = "";
            }
        }

        /*******************************************************
        * Nombre: TxCuenta_Leave
        * Descripcion: Actualiza el texto de un elemento de la ventana.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void TxCuenta_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxCorreo.Text))
            {
                TxCorreo.Text = "Correo";
            }
        }

        /*******************************************************
        * Nombre: TxContrasena_Enter
        * Descripcion: Actualiza el texto de un elemento de la ventana.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void TxContrasena_Enter(object sender, EventArgs e)
        {
            if (TxContrasena.Text == "Contraseña")
            {
                TxContrasena.Text = "";
                TxContrasena.PasswordChar = '*';
            }
        }

        /*******************************************************
        * Nombre: TxContrasena_Leave
        * Descripcion: Actualiza el texto de un elemento de la ventana.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
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
