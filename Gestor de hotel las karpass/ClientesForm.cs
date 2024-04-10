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
    public partial class ClientesForm : Form
    {
        private ConexionBD conexion;
        private FuncionesAux funcionesAux;
        private int idEmpleado;

        public ClientesForm(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
            actualizarDataView();
        }

        public void actualizarDataView()
        {
            conexion.abrir();
            string query = "SELECT identificacionCliente AS 'IdCliente', nombre AS 'Nombre', paisProcedencia AS 'Pais Origen', telefono AS 'Telefono', correo AS 'Correo' FROM Clientes";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataViewClientes.DataSource = tabla;
            conexion.cerrar();
        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            // Verifica si hay datos en los campos obligatorios
            if (string.IsNullOrWhiteSpace(textIdentificacionCliente.Text) || 
                string.IsNullOrWhiteSpace(textNombre.Text) || 
                string.IsNullOrWhiteSpace(textApellido1.Text) ||
                string.IsNullOrWhiteSpace(textPais.Text) || 
                string.IsNullOrWhiteSpace(textTelefono.Text) ||
                string.IsNullOrWhiteSpace(textCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO Clientes (identificacionCliente, nombre, primerApellido, segundoApellido, paisProcedencia, telefono, correo)" +
                           "VALUES (@identificacionCliente, @nombre, @primerApellido, @segundoApellido, @paisProcedencia, @telefono, @correo)";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@identificacionCliente", textIdentificacionCliente.Text);
            comando.Parameters.AddWithValue("@nombre", textNombre.Text);
            comando.Parameters.AddWithValue("@primerApellido", textApellido1.Text);
            comando.Parameters.AddWithValue("@segundoApellido", textApellido2.Text);
            comando.Parameters.AddWithValue("@paisProcedencia", textPais.Text);
            comando.Parameters.AddWithValue("@telefono", textTelefono.Text);
            comando.Parameters.AddWithValue("@correo", textCorreo.Text);

            try
            {
                conexion.abrir();
                comando.ExecuteNonQuery();
                MessageBox.Show("La persona: " + textNombre.Text + " se ha agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarDataView();

                textIdentificacionCliente.Text = "";
                textNombre.Text = "";
                textApellido1.Text = "";
                textApellido2.Text = "";
                textPais.Text = "";
                textTelefono.Text = "";
                textCorreo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la persona: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }


        private void BtActualizar_Click(object sender, EventArgs e)
        {

        }

        private void BtEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (DataViewClientes.SelectedRows.Count > 0)
            {
                // Obtiene el identificador de cliente de la fila seleccionada
                int identificacionCliente = Convert.ToInt32(DataViewClientes.SelectedRows[0].Cells["IdCliente"].Value);

                // Prepara la consulta SQL para eliminar el cliente
                string query = "DELETE FROM Clientes WHERE identificacionCliente = @identificacionCliente";
                SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
                comando.Parameters.AddWithValue("@identificacionCliente", identificacionCliente);

                try
                {
                    conexion.abrir();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("El cliente ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualiza la vista del DataGridView después de eliminar el cliente
                        actualizarDataView();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el cliente seleccionado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.cerrar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
