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
    public partial class ActualizarClienteForm : Form
    {
        private ConexionBD conexion;
        private decimal idClienteSeleccionado;

        /*******************************************************
         * Nombre: ActualizarClienteForm
         * Descripcion: Funcion la cual inicializa la ventana y la actualiza. Ademas de iniciar una conexion
         * con la BD.
         * Entradas:(Decimal) Con la id del cliente a mostrar sus datos.
         * Salidad:
         * *******************************************************/
        public ActualizarClienteForm(decimal idClienteSeleccionado)
        {
            InitializeComponent();
            conexion = new ConexionBD();
            this.idClienteSeleccionado = idClienteSeleccionado;

            actualizarDataView();
            CargarDatosCliente(idClienteSeleccionado);
        }

        /*******************************************************
         * Nombre: actualizarDataView
         * Descripcion: Saca la informacion del cliente de la BD y la almacena en una tabla para presentarla.
         * Entradas:
         * Salidad:
         * *******************************************************/
        public void actualizarDataView()
        {
            conexion.abrir();
            string query = "SELECT identificacionCliente AS 'IdCliente', nombre AS 'Nombre', primerApellido AS 'Primer apellido', segundoApellido AS 'Segundo Apellido', " +
                            "paisProcedencia AS 'País origen', telefono AS 'Telefono', correo AS 'Correo' FROM Clientes WHERE identificacionCliente = @idClienteSeleccionado";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@idClienteSeleccionado", idClienteSeleccionado.ToString());
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataViewActualizar.DataSource = tabla;
            conexion.cerrar();
        }


        /*******************************************************
         * Nombre: BtActualizar_Click
         * Descripcion: Actualiza la informacion de un cliente en la BD.
         * Entradas:un objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            // Verificar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(textApellido1.Text) ||
                string.IsNullOrWhiteSpace(textApellido2.Text) ||
                string.IsNullOrWhiteSpace(textPais.Text) ||
                string.IsNullOrWhiteSpace(textCorreo.Text) ||
                string.IsNullOrWhiteSpace(textTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Construir la consulta SQL de actualización
            string query = "UPDATE Clientes SET nombre = @nuevoNombre, primerApellido = @nuevoApellido1, segundoApellido = @nuevoApellido2, " +
                           "paisProcedencia = @nuevoPais, telefono = @nuevoTelefono, correo = @nuevoCorreo, " +
                           "ultimaModificacion = @ultimaModificacion WHERE identificacionCliente = @idCliente";

            // Crear el comando SQL y asignar parámetros
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@idCliente", idClienteSeleccionado);
            comando.Parameters.AddWithValue("@nuevoNombre", textNombre.Text);
            comando.Parameters.AddWithValue("@nuevoApellido1", textApellido1.Text);
            comando.Parameters.AddWithValue("@nuevoApellido2", textApellido2.Text);
            comando.Parameters.AddWithValue("@nuevoPais", textPais.Text);
            comando.Parameters.AddWithValue("@nuevoTelefono", textTelefono.Text);
            comando.Parameters.AddWithValue("@nuevoCorreo", textCorreo.Text);
            
            try
            {
                conexion.abrir();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Puedes añadir aquí cualquier lógica adicional después de actualizar
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        /*******************************************************
        * Nombre: CargarDatosCliente
        * Descripcion: Saca los datos de un cliente de la BD y la almacena en la ventana.
        * Entradas:(decimal) Id del cliente a buscar.
        * Salidad:
        * *******************************************************/
        private void CargarDatosCliente(decimal idCliente)
        {
            conexion.abrir();
            string query = "SELECT identificacionCliente, nombre, primerApellido, segundoApellido, paisProcedencia, telefono, correo " +
                           "FROM Clientes WHERE identificacionCliente = @idCliente";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                textIdentificacion.Text = reader["identificacionCliente"].ToString();
                textNombre.Text = reader["nombre"].ToString();
                textApellido1.Text = reader["primerApellido"].ToString();
                textApellido2.Text = reader["segundoApellido"].ToString();
                textPais.Text = reader["paisProcedencia"].ToString();
                textTelefono.Text = reader["telefono"].ToString();
                textCorreo.Text = reader["correo"].ToString();
            }

            conexion.cerrar();
        }
    }

}
