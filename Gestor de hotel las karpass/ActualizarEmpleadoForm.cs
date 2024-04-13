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
    public partial class ActualizarEmpleadoForm : Form
    {
        private ConexionBD conexion;
        private int idEmpleadoSelecionado;

        public ActualizarEmpleadoForm(int idEmpleadoSelecionado)
        {
            InitializeComponent();
            conexion = new ConexionBD();
            this.idEmpleadoSelecionado = idEmpleadoSelecionado;

            // Agrega elementos a la box Genero
            boxGenero.Items.Add("Masculino");
            boxGenero.Items.Add("Femenino");
            boxGenero.SelectedIndex = 0;

            // Agrega elemento a la box Rol
            boxRol.Items.Add("Administardor");
            boxRol.Items.Add("Recepcionista");
            boxRol.Items.Add("Control de plataforma");
            boxRol.SelectedIndex = 0;

            actualizarDataView();
            CargarDatosEmpleado(idEmpleadoSelecionado);
        }

        public void actualizarDataView()
        {
            conexion.abrir();
            string query = "SELECT nombre AS 'Nombre', primerApellido AS 'Primer apellido', segundoApellido AS 'Segundo Apellido', " +
                           "direccion AS 'Dirección', fechaNacimiento AS 'Fecha de nacimiento', " +
                           "(CASE " +
                           "WHEN idRol = 1 THEN 'Administrador' " +
                           "WHEN idRol = 2 THEN 'Recepcionista' " +
                           "WHEN idRol = 3 THEN 'Control de plataforma' " +
                           "ELSE 'Sin Rol' END) AS 'Rol', " +
                           "genero AS 'Género', telefono AS 'Telefono', correo AS 'Correo', " +
                           "contrasena AS 'Contraseña' FROM Empleados WHERE idEmpleado = @idEmpleadoSelecionado";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@idEmpleadoSelecionado", idEmpleadoSelecionado.ToString());
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataViewActualizar.DataSource = tabla;
            conexion.cerrar();
        }


        private void CargarDatosEmpleado(int idEmpleado)
        {
            conexion.abrir();
            string query = "SELECT nombre, primerApellido, segundoApellido, direccion, fechaNacimiento, " +
                                    "idRol, genero, telefono, correo, contrasena   FROM Empleados WHERE idEmpleado = @idEmpleado";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                textNombre.Text = reader["nombre"].ToString();
                textApellido1.Text = reader["primerApellido"].ToString();
                textApellido2.Text = reader["segundoApellido"].ToString();
                textDireccion.Text = reader["direccion"].ToString();
                textFechaNacimiento.Value = Convert.ToDateTime(reader["fechaNacimiento"]);
                boxRol.SelectedItem = ObtenerRol(Convert.ToInt32(reader["idRol"]));
                boxGenero.SelectedItem = reader["genero"].ToString();
                textTelefono.Text = reader["telefono"].ToString();
                textCorreo.Text = reader["correo"].ToString();
                textContrasena.Text = reader["contrasena"].ToString();
            }

            conexion.cerrar();
        }

        private void BtActualizar_Click(object sender, EventArgs e)
        {
            // Verifica si hay datos en los campos obligatorios
            if (string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(textApellido1.Text) ||
                string.IsNullOrWhiteSpace(textApellido2.Text) ||
                string.IsNullOrWhiteSpace(textDireccion.Text) ||
                string.IsNullOrWhiteSpace(textFechaNacimiento.Text) ||
                string.IsNullOrWhiteSpace(textCorreo.Text) ||
                string.IsNullOrWhiteSpace(textTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construir la consulta SQL de actualización
            string query = "UPDATE Empleados SET nombre = @nuevoNombre, primerApellido = @nuevoApellido1, segundoApellido = @nuevoApellido2, " +
                           "direccion = @nuevaDireccion, telefono = @nuevoTelefono, correo = @nuevoCorreo, idRol = @nuevoIdRol, " +
                           "ultimaModificacion = @ultimaModificacion WHERE idEmpleado = @idEmpleado";

            // Crear el comando SQL y asignar parámetros
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@nuevoNombre", textNombre.Text);
            comando.Parameters.AddWithValue("@nuevoApellido1", textApellido1.Text);
            comando.Parameters.AddWithValue("@nuevoApellido2", textApellido2.Text);
            comando.Parameters.AddWithValue("@nuevaDireccion", textDireccion.Text);
            comando.Parameters.AddWithValue("@nuevoTelefono", textTelefono.Text);
            comando.Parameters.AddWithValue("@nuevoCorreo", textCorreo.Text);
            comando.Parameters.AddWithValue("@nuevoIdRol", ObtenerIdRol(boxRol.SelectedItem.ToString())); 
            comando.Parameters.AddWithValue("@ultimaModificacion", ObtenerFechaActual());
            comando.Parameters.AddWithValue("@idEmpleado", idEmpleadoSelecionado);

            try
            {
                conexion.abrir();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDataView(); // Actualizar la vista después de la actualización
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private string ObtenerFechaActual()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string ObtenerRol(int idRol)
        {
            switch (idRol)
            {
                case 1:
                    return "Administardor";
                case 2:
                    return "Recepcionista";
                case 3:
                    return "Control de plataforma";
                default:
                    return "No definido"; // O un valor por defecto adecuado
            }
        }

        // Función para obtener el idRol según el tipo de usuario
        private int ObtenerIdRol(string rol)
        {
            switch (rol)
            {
                case "Administardor":
                    return 1;
                case "Recepcionista":
                    return 2;
                case "Control de plataforma":
                    return 3;
                default:
                    return -1; // Valor por defecto en caso de no coincidir
            }
        }

    }
}
