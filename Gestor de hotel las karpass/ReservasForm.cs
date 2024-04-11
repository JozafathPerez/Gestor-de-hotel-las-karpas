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
        int cantMaxPersonas;

        public ReservasForm(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
            ActualizarDataView();
            ActualizarClientesCombobox();
            ActualizarHabitacionesDisponibles();
        }

        private void ActualizarDataView()
        {
            conexion.abrir();
            string query = "SELECT numeroReserva AS [Num.], inicioReserva AS Inicio, finReserva AS Fin, " +
                           "cantPersonas AS Personas, costoTotal AS Costo, identificacionCliente AS Cliente, " +
                           "idEmpleado AS Encargado " +
                           "FROM Reservas " +
                           "WHERE cancelacionPendiente = 0 " +
                           "ORDER BY numeroReserva DESC";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataViewReservas.DataSource = tabla;
            conexion.cerrar();
        }

        private void ActualizarClientesCombobox()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar informacion de Clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void ActualizarHabitacionesDisponibles()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar informacion de Habitaciones: " + ex.Message);
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void BtGuardar_Click(object sender, EventArgs e)
        {
            //Validar campos vacios

            // Traer info de identificacion cliente
            string idCliente = comboBoxCliente.SelectedText.Split(':')[0];

            // Traer info de las fechas
            DateTime inicio = datePickerInicio.Value;
            DateTime fin = datePickerFin.Value;

            if (fin < inicio) // en caso de que los valores de inicio y fin esten al revez
            {
                MessageBox.Show("Las fecha de inicio debe ser antes que la de fecha de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string inicioString = $"{inicio.Year}-{inicio.Month}-{inicio.Day}";
            string finString = $"{fin.Year}-{fin.Month}-{fin.Day}";

            // Traer info de cantidad de personas
            Int32.TryParse(numericCantPersonas.Text, out int cantPersonas);
            if (cantPersonas > cantMaxPersonas)
            {
                MessageBox.Show("La cantidad de personas sobrepasa el maximo total que alcanzan en las habitaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ejecutar INSERT
            try
            {
                conexion.abrir();
                string query = $"INSERT INTO Reservas VALUES ({idCliente}, {inicioString}, {finString}, {cantPersonas}, NULL, {idEmpleado})";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);

                command.ExecuteNonQuery();
                MessageBox.Show("La reserva se ha agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ActualizarDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la Reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }

        }

        private void btnConfirmarHabitaciones_Click(object sender, EventArgs e)
        {
            ActualizarLabelsTotalHabitaciones();
        }

        private void ActualizarLabelsTotalHabitaciones()
        {
            double precioTotal = 0;
            int cantPersonasTotal = 0;
            for (int i = 0; i < checkedListHabitaciones.CheckedItems.Count; i++)
            {
                string itemString = checkedListHabitaciones.CheckedItems[i].ToString();
                string[] itemStringSplit = itemString.Split('\t');
                string precioString = funcionesAux.RemoverCaracteresNoNumericos(itemStringSplit[1]);
                string cantPersonasString = itemStringSplit[2].Split(' ')[0];
                Double.TryParse(precioString, out double precio);
                Int32.TryParse(cantPersonasString, out int cantPersonas);
                precioTotal += precio;
                cantPersonasTotal += cantPersonas;
            }
            // Traer info de las fechas
            DateTime inicio = datePickerInicio.Value;
            DateTime fin = datePickerFin.Value;
            int noches = (fin - inicio).Days;
            precioTotal *= noches;

            // Actualizar los labels
            labelCantPersonasMax.Text = "MAX " + cantPersonasTotal.ToString();
            labelPrecioTotal.Text = "Total: $" + precioTotal.ToString();

        }
    }
}
