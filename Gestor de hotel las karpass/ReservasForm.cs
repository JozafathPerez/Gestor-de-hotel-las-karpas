using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
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
        private Int64 idCliente;
        private int cantMaxPersonas;
        private int cantPersonas;
        private double precioReserva;
        private DateTime inicioReserva;
        private DateTime finReserva;
        private const int EDICION = 1;
        private const int LECTURA = 2;
        private List<(int numero, double precio, string tipo, int maxPersonas)> habitacionesSeleccionadas;


        // Inicio del sub-menu
        public ReservasForm(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
            habitacionesSeleccionadas = new List<(int numero, double precio, string tipo, int maxPersonas)>();
            inicioReserva = System.DateTime.Today;
            datePickerInicio.MinDate = inicioReserva;
            datePickerInicio.Value = inicioReserva;
            finReserva = System.DateTime.Today.AddDays(1);
            datePickerFin.MinDate = finReserva;
            datePickerFin.Value = finReserva;
            numericCantPersonas.Value = 1;
            ActualizarDataView();
            ActualizarClientesCombobox();
            ActualizarHabitacionesDisponibles();
        }


        // SeleccionarHabitaciones
        // Actualiza la lista de Habitaciones selccionadas
        private void SeleccionarHabitaciones()
        {
            // limpiar la lista
            habitacionesSeleccionadas.Clear();

            // por cada habitacion seleccionada
            for (int i = 0; i < checkedListHabitaciones.CheckedItems.Count; i++)
            {
                // crear tupla con info de la habitacion
                (int numero, double precio, string tipo, int maxPersonas) habitacion;
                string[] habitacionString = checkedListHabitaciones.CheckedItems[i].ToString().Split('\t');

                // convertir y guardar los datos en la tupla
                Int32.TryParse(habitacionString[0], out habitacion.numero);
                Double.TryParse(habitacionString[1].Substring(1), out habitacion.precio);
                habitacion.tipo = habitacionString[3];
                Int32.TryParse(funcionesAux.RemoverCaracteresNoNumericos(habitacionString[3]), out habitacion.maxPersonas);

                // guardar la habitacion en la lista
                habitacionesSeleccionadas.Add(habitacion);
            }
        }


        // Actualiza la tabla de informacion de las reservas
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


        // Actualiza los valores que se pueden seleccionar de combo box de cliente
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


        // Actualiza el check list con las habitaciones disponibles a reservar en el rango de fecha seleccionado
        private void ActualizarHabitacionesDisponibles()
        {
            try
            {
                // Traer informacion de la base de datos
                conexion.abrir();
                string query =
                    "SELECT DISTINCT h.numeroHabitacion, t.precio, t.nombreTipo, t.capacidadMax " +
                    "FROM hotel.dbo.Habitaciones h " +
                    "LEFT JOIN hotel.dbo.TiposHabitacion t ON h.idTipoHabitacion = t.idTipoHabitacion " +
                    "LEFT JOIN hotel.dbo.Reservashabitacion rh ON h.numeroHabitacion = rh.numeroHabitacion " +
                    "LEFT JOIN hotel.dbo.Reservas r ON rh.numeroReserva = r.numeroReserva " +
                    $"WHERE (r.numeroReserva IS NULL OR (r.inicioReserva > '{finReserva.ToString("yyyy-MM-dd")}' " +
                    $"OR r.finReserva < '{inicioReserva.ToString("yyyy-MM-dd")}'))";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    checkedListHabitaciones.Items.Clear();

                    // ciclar por los resultados y guardarlos como un item de la checklist
                    while (reader.Read())
                    {
                        string numHabitacion = reader[0].ToString();
                        string precio = reader[1].ToString();
                        string tipoHabitacion = reader[2].ToString();
                        string capacidadMax = reader[3].ToString();
                        checkedListHabitaciones.Items.Add($"{numHabitacion}\t${precio}\t\t{tipoHabitacion} ({capacidadMax}p max)");
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


        private void ActualizarTotales()
        {
            precioReserva = 0;
            cantMaxPersonas = 0;

            // Calcular precio total por noche 
            for (int i = 0; i < habitacionesSeleccionadas.Count; i++)
            {
                precioReserva += habitacionesSeleccionadas[i].precio;
                cantMaxPersonas += habitacionesSeleccionadas[i].maxPersonas;
            }

            int noches = (finReserva - inicioReserva).Days;
            precioReserva *= noches < 0 ? noches * -1 : noches;

            // Actualizar los labels
            labelCantPersonasMax.Text = "MAX " + cantMaxPersonas.ToString();
            labelPrecioTotal.Text = "Total: $" + precioReserva.ToString();
        }


        private bool datosReservaValidos()
        {
            // Validar formato del cliente
            string clienteString = comboBoxCliente.Text.Split(':')[0];
            if (Int64.TryParse(clienteString, out idCliente) == false)
            {
                MessageBox.Show("Debe seleccionar un cliente valido de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // validar existencia en BD del cliente
            conexion.abrir();
            string query = $"SELECT COUNT(identificacionCliente) FROM Clientes WHERE identificacionCliente = {clienteString}";
            SqlCommand cmd = new SqlCommand(query, conexion.ConectarBD);
            if ((int)cmd.ExecuteScalar() == 0)
            {
                conexion.cerrar();
                MessageBox.Show("El cliente seleccionado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            conexion.cerrar();

            // validar fechas alrevez
            if (finReserva < inicioReserva) // en caso de que los valores de inicio y fin esten al revez
            {
                MessageBox.Show("Las fecha de inicio debe ser antes que la de fecha de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // validar rango de fechas de un día o más
            if (finReserva == inicioReserva)
            {
                MessageBox.Show("La fecha de inicio y de final no pueden ser iguales (debe haber un rango de 1 día o más)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // validar que haya habitaciones seleccionadas
            if (habitacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int guardarReservaBD()
        {
            try
            {
                conexion.abrir();
                // crear comando
                string query =
                    "INSERT INTO Reservas " +
                    "(identificacionCliente, inicioReserva, finReserva, cantPersonas, costoTotal, idEmpleado) " +
                    "VALUES " +
                    "(@identificacionCliente, @inicioReserva, @finReserva, @cantPersonas, @costoTotal, @idEmpleado); " +
                    "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(query, conexion.ConectarBD);
                cmd.Parameters.AddWithValue("@identificacionCliente", idCliente);
                cmd.Parameters.AddWithValue("@inicioReserva", inicioReserva.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@finReserva", finReserva.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@cantPersonas", cantPersonas);
                cmd.Parameters.AddWithValue("@costoTotal", precioReserva);
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                // ejecutar y retornar el id de la nueva reserva
                Int32.TryParse(cmd.ExecuteScalar().ToString(), out int idReserva);
                return idReserva;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar guardar reserva en la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void guardarReservasHabitacionBD(int numReserva)
        {
            try
            {
                conexion.abrir();
                for (int i = 0; i < habitacionesSeleccionadas.Count; i++)
                {
                    (int numero, double precio, string tipo, int maxPersonas) habitacion = habitacionesSeleccionadas[i];
                    // crear comando
                    string query =
                        "INSERT INTO ReservasHabitacion " +
                        "VALUES " +
                        "(@numeroHabitacion, @numeroReserva, @costoHabitacion)";
                    SqlCommand cmd = new SqlCommand(query, conexion.ConectarBD);
                    cmd.Parameters.AddWithValue("@numeroHabitacion", habitacion.numero);
                    cmd.Parameters.AddWithValue("@numeroReserva", numReserva);
                    cmd.Parameters.AddWithValue("@costoHabitacion", habitacion.precio);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar guardar reservas de habitacion en la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
        }

        private void LimpiarEntradas()
        {
            comboBoxCliente.Text = string.Empty;
            datePickerInicio.Value = DateTime.Today;
            datePickerFin.Value = DateTime.Today.AddDays(1);
            numericCantPersonas.Value = 1;
            ActualizarHabitacionesDisponibles();
            ActualizarTotales();
        }

        // Valida y guarda en la BD la informacion de la reserva
        private void BtGuardar_Click(object sender, EventArgs e)
        {
            if (!(datosReservaValidos())) return;
            
            int numReserva = guardarReservaBD(); // guardar reserva
            if (numReserva == 0) return; // validar si no hubo un problema con el guardado
            guardarReservasHabitacionBD(numReserva);

            LimpiarEntradas();
            ActualizarDataView();
        }

        private void datePickerFin_ValueChanged(object sender, EventArgs e)
        {
            finReserva = datePickerFin.Value;
            ActualizarTotales();
        }

        private void datePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            inicioReserva = datePickerInicio.Value;
            ActualizarTotales();
        }

        private void checkedListHabitaciones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                SeleccionarHabitaciones();
                ActualizarTotales();
                numericCantPersonas.Minimum = 1;
                numericCantPersonas.Maximum = cantMaxPersonas;
            }));
        }

        private void numericCantPersonas_ValueChanged(object sender, EventArgs e)
        {
            cantPersonas = (int)numericCantPersonas.Value;
        }
    }
}
