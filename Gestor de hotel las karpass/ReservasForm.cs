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
    public partial class ReservasForm : Form
    {
        private ConexionBD conexion;
        private FuncionesAux funcionesAux;
        private int idEmpleado;
        const int EDICION = 1;
        const int LECTURA = 2;

        public ReservasForm(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
            actualizarClientesCombobox();
            actualizarHabitacionesDisponibles();
        }

        private void actualizarClientesCombobox()
        {
            try
            {
                conexion.abrir();
                string query = "SELECT identificacionCliente, nombre + ' ' + primerApellido AS nombreCompleto FROM Clientes ORDER BY nombreCompleto ASC";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    comboBoxCliente.Items.Clear();

                    while (reader.Read())
                    {
                        string id = reader[0].ToString();
                        string nombre = reader[1].ToString();
                        comboBoxCliente.Items.Add(id + ": " + nombre);
                    }
                }
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar informacion de Clientes: " + ex.Message);
            }

        }

        private void actualizarHabitacionesDisponibles()
        {
            try
            {
                conexion.abrir();
                string query =
                    "SELECT h.numeroHabitacion, t.Precio, t.capacidadMax " +
                    "FROM Habitaciones AS h " +
                    "INNER JOIN TiposHabitacion AS t ON h.idTipoHabitacion = t.idTipoHabitacion " +
                    "WHERE estadoOcupado = 0 " +
                    "ORDER BY h.numeroHabitacion ASC";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    checkedListHabitaciones.Items.Clear();

                    while (reader.Read())
                    {
                        string numHabitacion = reader[0].ToString();
                        string precio = reader[1].ToString();
                        string capacidadMax = reader[2].ToString();
                        checkedListHabitaciones.Items.Add(numHabitacion + "\t $" + precio + "\t" + capacidadMax + " P. Max");
                    }
                }
                conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar informacion de Habitaciones: " + ex.Message);
            }

        }

        private void CheckedListHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            double precioTotal = 0;
            double cantPersonasTotal = 0;
            for (int i = 0; i < checkedListHabitaciones.CheckedItems.Count; i++)
            {
                string itemString = checkedListHabitaciones.CheckedItems[i].ToString();
                string[] itemStringSplit = itemString.Split('\t');
                string precioString = funcionesAux.RemoverCaracteresNoNumericos(itemStringSplit[1]);
                string cantPersonasString = funcionesAux.RemoverCaracteresNoNumericos(itemStringSplit[2]);
                Double.TryParse(precioString, out double precio);
                Double.TryParse(cantPersonasString, out double cantPersonas);
                precioTotal += precio;
                cantPersonasTotal += cantPersonas;

            }

            // Actualizar los labels
            labelCantPersonasMax.Text = "MAX " + cantPersonasTotal.ToString();
            labelPrecioTotal.Text = "Total: $" + precioTotal.ToString();
        }
    }
}
