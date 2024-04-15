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
    public partial class DetallesReservaForm : Form
    {
        private ConexionBD conexion;
        private FuncionesAux funcionesAux;
        private int numeroReserva;
        private int idEmpleado;
        private Decimal idCliente;
        private string nombreCliente;
        private string apellidoCliente;
        private int cantMaxPersonas;
        private int cantPersonas;
        private double precioReserva;
        private DateTime inicioReserva;
        private DateTime finReserva;
        private const int ADMINISTRADOR = 1;
        private List<(int numero, double precio, string tipo, int maxPersonas)> habitacionesSeleccionadas;
        DateTime fechaCreacion;

        public DetallesReservaForm(int numeroReserva, int permisos)
        {
            conexion = new ConexionBD();
            this.numeroReserva = numeroReserva;
            funcionesAux = new FuncionesAux(conexion);
            habitacionesSeleccionadas = new List<(int numero, double precio, string tipo, int maxPersonas)>();
            InitializeComponent();
            ActualizarClientesCombobox();
            CargarInfoReserva();
            ActualizarHabitacionesDisponibles();
            SeleccionarHabitaciones();
            ActualizarTotales();
            if (permisos == ADMINISTRADOR) 
            {
                BtGuardar.Show();
            } else
            {
                BtGuardar.Hide();
            }
        }

        /**
          * Calcula el descuento y devuelve el descuento de segun la temporada que se encuentre
          * el día actual.
          */
        private int DescuentoTemporada()
        {
            DateTime fecha = fechaCreacion;

            // Definir las fechas de inicio y fin para cada temporada
            DateTime inicioTemporadaAlta = new DateTime(fecha.Year, 6, 15);
            DateTime finTemporadaAlta = new DateTime(fecha.Year, 9, 14);
            DateTime inicioTemporadaMedia = new DateTime(fecha.Year, 9, 15);
            DateTime finTemporadaMedia = new DateTime(fecha.Year, 2, 14);
            DateTime inicioTemporadaBaja = new DateTime(fecha.Year, 2, 15);
            DateTime finTemporadaBaja = new DateTime(fecha.Year, 6, 14);

            // Determinar en qué temporada se encuentra la reserva
            int descuento = 0;
            if (inicioTemporadaAlta <= fecha && fecha <= finTemporadaAlta)
                descuento = 0;
            else if (inicioTemporadaMedia <= fecha && fecha <= finTemporadaMedia)
                descuento = 30;
            else if (inicioTemporadaBaja <= fecha && fecha <= finTemporadaBaja)
                descuento = 40;

            return descuento;
        }

        /// <summary>
        /// Calcula el descuento basado en las reservas que realizó un cliente en el año.
        /// </summary>
        /// <param name="idCliente">identificacion del cliente para buscarlo en la BD</param>
        /// <returns>tupla con forma (descuento, noches_gratis). El descuento es un multiplicador de 0-1</returns>
        private (int, int) DescuentoClienteFrecuente(Decimal idCliente)
        {
            int descuento = 0;
            int nochesGratis = 0;
            try
            {
                conexion.abrir();
                string query =
                    "SELECT COUNT(identificacionCliente) " +
                    "FROM Reservas " +
                    "WHERE identificacionCliente = @identificacionCliente ";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                command.Parameters.AddWithValue("@identificacionCliente", idCliente);
                int cantReservas = (int)command.ExecuteScalar();

                // Calcular descuentos
                if (5 == cantReservas)
                    descuento = 5;
                else if (5 <= cantReservas && cantReservas <= 9)
                    descuento = 10;
                else if (cantReservas >= 10)
                {
                    nochesGratis = (int)Math.Floor((double)(cantReservas / 10));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular descuento por cantidad de reservas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descuento = 0;
                nochesGratis = 0;
            }
            finally
            {
                conexion.cerrar();
            }

            return (descuento, nochesGratis);
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

        private void CargarInfoReserva()
        {
            try
            {
                // Traemos la informacion general de la base de datos (las habitaciones especificas después...)
                conexion.abrir();
                string query =
                    "SELECT r.numeroReserva, r.identificacionCliente, c.nombre, c.primerApellido, r.idEmpleado, " +
                    "r.inicioReserva, r.finReserva, r.cantPersonas, r.fechaCreacion " +
                    "FROM Reservas r " +
                    "LEFT JOIN Clientes c ON r.identificacionCliente = c.identificacionCliente " +
                    "WHERE r.numeroReserva = @numeroReserva";
                SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
                comando.Parameters.AddWithValue("@numeroReserva", numeroReserva);

                // leeemos los datos y los guardamos en las variables de la clase
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idCliente = reader.GetDecimal(1);
                        nombreCliente = reader.GetString(2);
                        apellidoCliente = reader.GetString(3);
                        idEmpleado = reader.GetInt32(4);
                        inicioReserva = reader.GetDateTime(5).ToUniversalTime();
                        finReserva = reader.GetDateTime(6).ToUniversalTime();
                        cantPersonas = reader.GetInt32(7);
                        fechaCreacion = reader.GetDateTime(8).ToUniversalTime();
                    }
                }

                // actualizamos los datos de la Interfaz
                labelNumReserva.Text = "N° reserva: " + numeroReserva.ToString();
                labelEncargado.Text = "Encargado " + idEmpleado.ToString();
                comboBoxCliente.Text = $"{idCliente}: {nombreCliente} {apellidoCliente}";
                datePickerInicio.Value = inicioReserva;
                datePickerFin.Value = finReserva;
                numericCantPersonas.Value = cantPersonas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recuperar informacion de la reserva {numeroReserva}: {ex.GetType()} {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                conexion.cerrar();
            }
        }

        // Actualiza el check list con las habitaciones disponibles a reservar en el rango de fecha seleccionado
        private void ActualizarHabitacionesDisponibles()
        {
            checkedListHabitaciones.Items.Clear();
            try
            {
                // Traer informacion de la base de datos
                conexion.abrir();
                string query =
                    "SELECT DISTINCT h.numeroHabitacion, t.precio, t.nombreTipo, t.capacidadMax, rh.numeroReserva " +
                    "FROM hotel.dbo.Habitaciones h " +
                    "LEFT JOIN hotel.dbo.TiposHabitacion t ON h.idTipoHabitacion = t.idTipoHabitacion " +
                    "LEFT JOIN hotel.dbo.Reservashabitacion rh ON h.numeroHabitacion = rh.numeroHabitacion " +
                    $"WHERE rh.numeroReserva = {numeroReserva}";
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
                        int indiceActual = checkedListHabitaciones.Items.Add($"{numHabitacion}\t${precio}\t\t{tipoHabitacion} ({capacidadMax}p max)");
                        // Marcar el item con check si pertence a la reserva
                        if (numeroReserva == reader.GetInt32(4))
                            checkedListHabitaciones.SetItemCheckState(indiceActual, CheckState.Checked);
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
            SeleccionarHabitaciones();
            ActualizarTotales();
            normalizarNumericCantPersonas();
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

            // Calcular Descuentos
            (int descuentoCliente, int nochesGratis) = DescuentoClienteFrecuente(idCliente);
            int descuentoTemporada = DescuentoTemporada();
            double descuentoNochesGratis = precioReserva * nochesGratis;

            // Calcular por noches
            int noches = (finReserva - inicioReserva).Days;
            precioReserva *= noches < 0 ? noches * -1 : noches;

            double totalSinDescuento = precioReserva;

            // Aplicar descuentos
            precioReserva = precioReserva - descuentoNochesGratis;
            precioReserva = precioReserva - (precioReserva * (descuentoCliente * 0.01));
            precioReserva = precioReserva - (precioReserva * (descuentoTemporada * 0.01));

            // Actualizar los labels
            string detallesString =
                $"${totalSinDescuento}";
            if (descuentoCliente > 0)
                detallesString += $"\r\n-{descuentoCliente}% (cliente frecuente)";
            if (descuentoTemporada > 0)
                detallesString += $"\r\n-{descuentoTemporada}% (temporada)";
            if (nochesGratis > 0)
                detallesString += $"\r\n-{nochesGratis} noches gratis";
            labelPrecioDetalles.Text = detallesString;
            labelCantPersonasMax.Text = "MAX " + cantMaxPersonas.ToString();
            labelPrecioTotal.Text = "Total: $" + precioReserva.ToString();
        }

        private void checkedListHabitaciones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    SeleccionarHabitaciones();
                    ActualizarTotales();
                    normalizarNumericCantPersonas();
                }));
            }
            catch (InvalidOperationException) // Para cuando se cambien los checks mientras se crea la ventana
            {
                return; // simplemente lo omitimos
            }
        }

        private void normalizarNumericCantPersonas()
        {
            if (cantMaxPersonas > 0)
            {
                numericCantPersonas.Maximum = cantMaxPersonas;
                numericCantPersonas.Minimum = 1;
                if (numericCantPersonas.Value == 0)
                {
                    numericCantPersonas.Value = 1;
                }
            }
            else
            {
                numericCantPersonas.Maximum = cantMaxPersonas;
                numericCantPersonas.Minimum = 0;
                numericCantPersonas.Value = 0;
            }
        }

        private bool datosReservaValidos()
        {
            // Validar formato del cliente
            string clienteString = comboBoxCliente.Text.Split(':')[0];
            if (Decimal.TryParse(clienteString, out idCliente) == false)
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

        private int ActualizarReservaBD()
        {
            int resultado = 0;
            try
            {
                conexion.abrir();
                string query =
                    "UPDATE Reservas " +
                    "SET " +
                    "identificacionCliente = @identificacionCliente, " +
                    "inicioReserva = @inicioReserva, " +
                    "finReserva = @finReserva, " +
                    "cantPersonas = @cantPersonas, " +
                    "costoTotal = @costoTotal, " +
                    "idEmpleado = @idEmpleado " +
                    "WHERE numeroReserva = @numeroReserva";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                // cambiar parametros
                command.Parameters.AddWithValue("@identificacionCliente", idCliente);
                command.Parameters.AddWithValue("@inicioReserva", inicioReserva.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@finReserva", finReserva.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@cantPersonas", cantPersonas);
                command.Parameters.AddWithValue("@costoTotal", precioReserva);
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                command.Parameters.AddWithValue("@numeroReserva", numeroReserva);
                
                resultado = command.ExecuteNonQuery(); // ejecutar UPDATE
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los valores en la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }
            return resultado;
        }

        // borra todas las reservas de habitacion que se hayan desmarcado en la ventana de modificaciond e reservas
        private void BorrarHabitacionDeseleccionadasBD(int numReserva) // TODO: ESTA BORRANDO LAS HABITACIONES MARCADAS (AL REVEZ)
        {
            try
            {
                // encontrar las habitaciones deseleccionadas
                List<int> habitacionesABorrar = new List<int>();

                for (int i = 0; i < checkedListHabitaciones.Items.Count; i++)
                {
                    if (checkedListHabitaciones.GetItemCheckState(i) == CheckState.Unchecked)
                    {
                        Int32.TryParse(checkedListHabitaciones.Items[i].ToString().Split('\t')[0], out int numBorrar);
                        habitacionesABorrar.Add(numBorrar);
                    }
                }
                Console.WriteLine(habitacionesABorrar.Count);

                conexion.abrir();
                for (int i = 0; i < habitacionesABorrar.Count; i++)
                {
                    // crear comando 
                    string query =
                        "DELETE FROM ReservasHabitacion " +
                        "WHERE numeroHabitacion = @numeroHabitacion AND numeroReserva = @numeroReserva";
                    SqlCommand cmd = new SqlCommand(query, conexion.ConectarBD);
                    cmd.Parameters.AddWithValue("@numeroHabitacion", habitacionesABorrar[i]);
                    cmd.Parameters.AddWithValue("@numeroReserva", numReserva);
                    int resultado = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Resultado: {resultado}, Habitacion: {habitacionesABorrar[i]}, Reserva: {numReserva}");
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

        // Valida y actualiza en la BD las modificaciones de la reserva
        private void BtGuardar_Click(object sender, EventArgs e)
        {
            if (!(datosReservaValidos())) return;

            int resultado = ActualizarReservaBD(); // guardar reserva
            if (resultado == 0) return; // en caso de un error al actualziar
            BorrarHabitacionDeseleccionadasBD(numeroReserva);
            this.Close();
        }

        private void numericCantPersonas_ValueChanged(object sender, EventArgs e)
        {
            cantPersonas = (int)numericCantPersonas.Value;
        }

        private void datePickerFin_ValueChanged(object sender, EventArgs e)
        {
            finReserva = datePickerFin.Value;
            ActualizarHabitacionesDisponibles();
            ActualizarTotales();
        }

        private void datePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            inicioReserva = datePickerInicio.Value;
            ActualizarHabitacionesDisponibles();
            ActualizarTotales();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clienteString = comboBoxCliente.Text.Split(':')[0];
            Decimal.TryParse(clienteString, out idCliente);
            ActualizarTotales();
        }
    }
}
