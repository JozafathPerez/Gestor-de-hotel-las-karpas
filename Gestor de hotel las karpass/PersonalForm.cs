﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestor_de_hotel_las_karpass
{
    public partial class PersonalForm : Form
    {
        private ConexionBD conexion;
        private FuncionesAux funcionesAux;

        /*******************************************************
        * Nombre: PersonalForm
        * Descripcion: Inicializa la ventana y actualiza sus elementos.
        * Entradas: 
        * Salidad: 
        * *******************************************************/
        public PersonalForm()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
            actualizarDataView();


            // Agrega elementos a la box Genero
            boxGenero.Items.Add("Masculino");
            boxGenero.Items.Add("Femenino");
            boxGenero.SelectedIndex = 0;

            // Agrega elemento a la box Rol
            boxRol.Items.Add("Administardor");
            boxRol.Items.Add("Recepcionista");
            boxRol.Items.Add("Control de plataforma");
            boxRol.SelectedIndex = 0;

        }

         /*******************************************************
        * Nombre: actualizarDataView
        * Descripcion: Actualiza un elemento de la ventana con datos de los empleados.
        * Entradas: 
        * Salidad: 
        * *******************************************************/
        
        public void actualizarDataView()
        {
            conexion.abrir();
            string query = "SELECT idEmpleado AS 'IdEmpleado', nombre AS 'Nombre', " +
                                    "(CASE " +
                                    "WHEN idRol = 1 THEN 'Administrador' " +
                                    "WHEN idRol = 2 THEN 'Recepcionista' " +
                                    "WHEN idRol = 3 THEN 'Control de plataforma' " +
                                    "ELSE 'Sin Rol' END) AS 'Rol', " +
                                    "correo AS 'Correo', contrasena AS 'Contraseña', telefono AS 'Telefono' FROM Empleados";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataViewPersonal.DataSource = tabla;
            conexion.cerrar();
        }

        /*******************************************************
        * Nombre: BtGuardar_Click
        * Descripcion: Almacena un empleado en la BD.
        * Entradas: 
        * Salidad: 
        * *******************************************************/
        private void BtGuardar_Click(object sender, EventArgs e)
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

            string query = "INSERT INTO Empleados (nombre, primerApellido, segundoApellido, direccion, fechaNacimiento, idRol, genero, " +
                                                   "telefono, correo, contrasena, ultimaModificacion, fechaCreacion)" +
                           "VALUES (@nombre, @primerApellido, @segundoApellido, @direccion, @fechaNacimiento, @idRol, @genero, " +
                           "@telefono, @correo, @contrasena, @ultimaModificacion, @fechaCreacion)";

            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            comando.Parameters.AddWithValue("@nombre", textNombre.Text);
            comando.Parameters.AddWithValue("@primerApellido", textApellido1.Text);
            comando.Parameters.AddWithValue("@segundoApellido", textApellido2.Text);
            comando.Parameters.AddWithValue("@direccion", textDireccion.Text);
            comando.Parameters.AddWithValue("@fechaNacimiento", textFechaNacimiento.Value.ToString("yyyy-MM-dd"));
            comando.Parameters.AddWithValue("@idRol", ObtenerIdRol(boxRol.SelectedItem.ToString()));
            comando.Parameters.AddWithValue("@genero", boxGenero.SelectedItem.ToString());
            comando.Parameters.AddWithValue("@telefono", textTelefono.Text);
            comando.Parameters.AddWithValue("@correo", textCorreo.Text);
            comando.Parameters.AddWithValue("@contrasena", GenerarContrasenaAleatoria());
            comando.Parameters.AddWithValue("@ultimaModificacion", ObtenerFechaActual());
            comando.Parameters.AddWithValue("@fechaCreacion", ObtenerFechaActual());

            try
            {
                conexion.abrir();
                comando.ExecuteNonQuery();
                MessageBox.Show("El empleado " + textNombre.Text + " se ha agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarDataView();

                textNombre.Text = "";
                textApellido1.Text = "";
                textApellido2.Text = "";
                textFechaNacimiento.Value = DateTime.Now;
                textCorreo.Text = "";
                textDireccion.Text = "";
                textTelefono.Text = "";
                boxGenero.SelectedIndex = 0;
                boxRol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }

         /*******************************************************
        * Nombre: ObtenerIdRol
        * Descripcion: Función para obtener el idRol según el tipo de usuario.
        * Entradas: (string) nombre del rol del empleado
        * Salidad: (int) Devuelve el id del rol
        * *******************************************************/
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

        /*******************************************************
        * Nombre: GenerarContrasenaAleatoria
        * Descripcion: Función para generar una contraseña aleatoria de 4 números.
        * Entradas: 
        * Salidad: (string) Devuelve la contraseña generada
        * *******************************************************/
        private string GenerarContrasenaAleatoria()
        {
            Random rnd = new Random();
            int num1 = rnd.Next(0, 10);
            int num2 = rnd.Next(0, 10);
            int num3 = rnd.Next(0, 10);
            int num4 = rnd.Next(0, 10);

            return $"{num1}{num2}{num3}{num4}";
        }

         /*******************************************************
       * Nombre: ObtenerFechaActual
       * Descripcion: Función para obtener la fecha actual en formato "yyyy-MM-dd HH:mm:ss".
       * Entradas: 
       * Salidad: (string) Devuelve la fecha actual
       * *******************************************************/
        private string ObtenerFechaActual()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /*******************************************************
       * Nombre: BtActualizar_Click
       * Descripcion: Actualiza una fila(empleado) seleccionada en el DataGridView de la ventana.
       * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
       * Salidad: 
       * *******************************************************/
        private void BtActualizar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (DataViewPersonal.SelectedRows.Count > 0)
            {
                // Obtener el idEmpleado de la fila seleccionada
                int idEmpleado = Convert.ToInt32(DataViewPersonal.SelectedRows[0].Cells["IdEmpleado"].Value);

                // Crear una instancia del formulario secundario
                ActualizarEmpleadoForm actualizarForm = new ActualizarEmpleadoForm(idEmpleado);

                // Mostrar el formulario secundario como una ventana emergente
                DialogResult resultado = actualizarForm.ShowDialog();

                // Actualizar la vista de datos u realizar otras acciones necesarias
                actualizarDataView();
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         /*******************************************************
       * Nombre: BtEliminar_Click
       * Descripcion: Elimina una fila(empleado) seleccionada en el DataGridView de la ventana.
       * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
       * Salidad: 
       * *******************************************************/
        private void BtEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (DataViewPersonal.SelectedRows.Count > 0)
            {
                // Obtiene el idEmpleado y el nombre de la fila seleccionada
                int idEmpleado = Convert.ToInt32(DataViewPersonal.SelectedRows[0].Cells["IdEmpleado"].Value);
                string nombreEmpleado = DataViewPersonal.SelectedRows[0].Cells["Nombre"].Value.ToString(); 

                // Pregunta al usuario si está seguro de eliminar al empleado
                DialogResult confirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar al empleado '{nombreEmpleado}'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Prepara la consulta SQL para eliminar el empleado
                    string query = "DELETE FROM Empleados WHERE idEmpleado = @idEmpleado";
                    SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
                    comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                    try
                    {
                        conexion.abrir();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("El empleado ha sido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualiza la vista del DataGridView después de eliminar el empleado
                            actualizarDataView();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el empleado seleccionado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conexion.cerrar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
