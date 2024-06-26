﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
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
        private const int ADMINISTRADOR = 1;
        private const int RECEPCIONISTA = 2;
        private const int CONTROL_PLATAFORMA = 3;
        private List<(int numero, double precio, string tipo, int maxPersonas)> habitacionesSeleccionadas;
        private int permisos;

        /*******************************************************
         * Nombre: ReservasForm.
         * Descripcion: Funcion que inicializa la ventana.
         * Entradas:(int) id del empleado que inicia sesion
         * Salidad:
         * *******************************************************/
        public ReservasForm(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
            habitacionesSeleccionadas = new List<(int numero, double precio, string tipo, int maxPersonas)>();
            inicioReserva = System.DateTime.Today.AddDays(2);
            datePickerInicio.MinDate = inicioReserva;
            datePickerInicio.Value = inicioReserva;
            finReserva = System.DateTime.Today.AddDays(3);
            datePickerFin.MinDate = finReserva;
            datePickerFin.Value = finReserva;
            buttonConfirmarCancelacion.Hide();
            ValidarPermisos();
            ActualizarDataViewTodo();
            ActualizarClientesCombobox();
            ActualizarHabitacionesDisponibles();
        }

        /*******************************************************
         * Nombre: ValidarPermisos.
         * Descripcion: Funcion que valida el rango del empleado y las funciones a las que tiene acceso
         * si no tiene acceso a alguna, esta se bloquea.
         * Entradas:
         * Salidad:
         * *******************************************************/
        private void ValidarPermisos()
        {
            // obtener permisos
            try
            {
                conexion.abrir();
                string query =
                    "SELECT idRol " +
                    "FROM Empleados " +
                    "WHERE idEmpleado = @idEmpleado";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                permisos = (int) command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los persmisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrar();
            }

            // bloquear funciones base
            if (permisos == CONTROL_PLATAFORMA)
            {
                buttonModificar.Enabled = false;
                BtGuardar.Enabled = false;
                BtEliminar.Enabled = false;
            } else
            {
                buttonModificar.Enabled = true;
                BtEliminar.Enabled = true;
                BtGuardar.Enabled = true;
            }
        }

        /*******************************************************
         * Nombre: DescuentoTemporada.
         * Descripcion: Funcion que calcula el descuento y devuelve el descuento de según 
         * la temporada que se encuentre el día actual.
         * Entradas:
         * Salidad: (int) descuento segun la temporada
         * *******************************************************/
        private int DescuentoTemporada()
        {
            DateTime fecha = DateTime.Today;

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

        /*******************************************************
         * Nombre: DescuentoClienteFrecuente.
         * Descripcion: Funcion que calcula el descuento basado en las reservas que realizó un cliente en el año.
         * Entradas: (Decimal) id del cliente para buscarlo en la BD
         * Salidad: (int,int) Tupla con forma (descuento, noches_gratis). El descuento es un multiplicador de 0-1
         * *******************************************************/
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
                else if (6 <= cantReservas && cantReservas <= 9)
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

        /*******************************************************
         * Nombre: SeleccionarHabitaciones.
         * Descripcion: Funcion que actualiza la informacion interna de las habitaicones 
         * selccionadas en el checklist de habitaciones.
         * Entradas: 
         * Salidad: 
         * *******************************************************/
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

        /*******************************************************
         * Nombre: ActualizarDataViewTodo.
         * Descripcion: Actualiza la tabla de información de todas las reservas.
         * Entradas: 
         * Salidad: 
         * *******************************************************/
        private void ActualizarDataViewTodo()
        {
            // Bloquear/ activar funciones relacionadas
            buttonModificar.Show();
            BtEliminar.Show();
            BtGuardar.Show();
            buttonConfirmarCancelacion.Hide();

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

        /*******************************************************
         * Nombre: SeleccionarHabitaciones.
         * Descripcion: Funcion que actualiza la tabla de información de las cancelaciones.
         * Entradas: 
         * Salidad: 
         * *******************************************************/
        private void ActualizarDataViewCancelaciones()
        {
            // Bloquear/ activar funciones relacionadas
            buttonModificar.Hide();
            BtEliminar.Hide();
            BtGuardar.Hide();
            if (permisos == ADMINISTRADOR)
            {
                buttonConfirmarCancelacion.Show();
            }

            // Actualziar dataview
            conexion.abrir();
            string query = "SELECT numeroReserva AS [Num.], inicioReserva AS Inicio, finReserva AS Fin, fechaCancelacion AS Cancelacion, " +
                           "cantPersonas AS Personas, costoTotal AS Costo, identificacionCliente AS Cliente, " +
                           "idEmpleado AS Encargado " +
                           "FROM Reservas " +
                           "WHERE cancelacionPendiente = 1 " +
                           "ORDER BY numeroReserva DESC";
            SqlCommand comando = new SqlCommand(query, conexion.ConectarBD);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataViewReservas.DataSource = tabla;
            conexion.cerrar();
        }

        /*******************************************************
         * Nombre: ActualizarClientesCombobox.
         * Descripcion: Funcion que Actualiza los valores del combo box de clientes.
         * Entradas: 
         * Salidad: 
         * *******************************************************/
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


        /*******************************************************
         * Nombre: ActualizarHabitacionesDisponibles.
         * Descripcion: Funcion que Actualiza el check list con las habitaciones disponibles para reservar.
         * Entradas: 
         * Salidad: 
         * *******************************************************/
        private void ActualizarHabitacionesDisponibles()
        {
            try
            {
                // Traer informacion de la base de datos
                conexion.abrir();
                string query = @"
                    SELECT DISTINCT h.numeroHabitacion, t.precio, t.nombreTipo, t.capacidadMax 
                    FROM hotel.dbo.Habitaciones h 
                    LEFT JOIN hotel.dbo.TiposHabitacion t ON h.idTipoHabitacion = t.idTipoHabitacion 
                    WHERE h.numeroHabitacion NOT IN 
                    (
                        SELECT rh.numeroHabitacion 
                        FROM hotel.dbo.Reservashabitacion rh 
                        INNER JOIN hotel.dbo.Reservas r ON rh.numeroReserva = r.numeroReserva 
                        WHERE 
                        (
                            r.inicioReserva <= @finReserva 
                            AND r.finReserva >= @inicioReserva
                        ) 
                        OR 
                        (
                            r.finReserva >= @inicioReserva 
                            AND r.inicioReserva <= @finReserva
                        )
                        OR
                        (
                            r.inicioReserva >= @inicioReserva 
                            AND r.finReserva <= @finReserva
                        )
                    )";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                command.Parameters.AddWithValue("@inicioReserva", inicioReserva.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@finReserva", finReserva.ToString("yyyy-MM-dd"));

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
            SeleccionarHabitaciones();
            ActualizarTotales();
            normalizarNumericCantPersonas();
        }

        /*******************************************************
         * Nombre: ActualizarTotales.
         * Descripcion: Funcion que Actualiza los totales del precio de la reserva.
         * Entradas: 
         * Salidad: 
         * *******************************************************/
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


        /*******************************************************
         * Nombre: datosReservaValidos.
         * Descripcion: Funcion que Valida si los datos de la reserva son válidos.
         * Entradas: 
         * Salidad:(bool) True si los datos son válidos, False si no lo son
         * *******************************************************/
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

        /*******************************************************
         * Nombre: guardarReservaBD.
         * Descripcion: Guarda la información de la reserva en la base de datos.
         * Entradas: 
         * Salidad:(int) El número de la reserva guardada
         * *******************************************************/
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

        /*******************************************************
         * Nombre: guardarReservasHabitacionBD.
         * Descripcion: Guarda las reservas de habitación en la base de datos.
         * Entradas: (int) El número de la reserva  
         * Salidad:
         * *******************************************************/
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

        /*******************************************************
         * Nombre: LimpiarEntradas.
         * Descripcion: Funcion que Limpia las entradas después de guardar una reserva.
         * Entradas:  
         * Salidad:
         * *******************************************************/
        private void LimpiarEntradas()
        {
            comboBoxCliente.Text = string.Empty;
            datePickerInicio.Value = DateTime.Today.AddDays(2);
            datePickerFin.Value = DateTime.Today.AddDays(3);
            ActualizarHabitacionesDisponibles();
            ActualizarTotales();
        }

        /*******************************************************
         * Nombre: BtGuardar_Click.
         * Descripcion: Funcion que guarda una reserva.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void BtGuardar_Click(object sender, EventArgs e)
        {
            if (!(datosReservaValidos())) return;
            
            int numReserva = guardarReservaBD(); // guardar reserva
            if (numReserva == 0) return; // validar si no hubo un problema con el guardado
            guardarReservasHabitacionBD(numReserva);

            LimpiarEntradas();
            ActualizarDataViewTodo();
        }

        /*******************************************************
         * Nombre: datePickerFin_ValueChanged.
         * Descripcion: Funcion que cambia una fecha de fin almacenada en una variable.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void datePickerFin_ValueChanged(object sender, EventArgs e)
        {
            finReserva = datePickerFin.Value;
            ActualizarHabitacionesDisponibles();
            ActualizarTotales();
        }

        /// <summary>
        /// Evento al cambiar el valor del selector de fecha de inicio.
        /// </summary>
        private void datePickerInicio_ValueChanged(object sender, EventArgs e)
        {
            inicioReserva = datePickerInicio.Value;
            ActualizarHabitacionesDisponibles();
            ActualizarTotales();
        }

        /*******************************************************
         * Nombre: checkedListHabitaciones_ItemCheck.
         * Descripcion: Funcion que marca o desmarcar un elemento de la lista de habitaciones.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void checkedListHabitaciones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                SeleccionarHabitaciones();
                ActualizarTotales();
                normalizarNumericCantPersonas();
            }));
        }


        /*******************************************************
         * Nombre: normalizarNumericCantPersonas.
         * Descripcion: Funcion que Normaliza el valor del selector de cantidad de personas.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
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


        /*******************************************************
         * Nombre: numericCantPersonas_ValueChanged.
         * Descripcion: Funcion que cambia el valor del selector de cantidad de personas.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void numericCantPersonas_ValueChanged(object sender, EventArgs e)
        {
            cantPersonas = (int)numericCantPersonas.Value;
        }

        /*******************************************************
         * Nombre: buttonModificar_Click.
         * Descripcion: Funcion que Abre una ventana con los detalles de la reserva seleccionada para modificarla.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (!(DataViewReservas.SelectedRows.Count == 1))
            {
                MessageBox.Show("Para realizar esta acción debe seleccionar UNA reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idReserva = (int) DataViewReservas.SelectedRows[0].Cells[0].Value;
            DetallesReservaForm detallesReservaForm = new DetallesReservaForm(idReserva, permisos);
            DialogResult dialogResult = detallesReservaForm.ShowDialog();
            ActualizarDataViewTodo();
            ActualizarHabitacionesDisponibles();
        }


        /*******************************************************
         * Nombre: comboBoxCliente_SelectedIndexChanged.
         * Descripcion: Funcion que cambia la seleccion del combo box de cliente
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clienteString = comboBoxCliente.Text.Split(':')[0];
            Int64.TryParse(clienteString, out idCliente);
            ActualizarTotales();
        }


         /*******************************************************
         * Nombre: comboBoxCliente_SelectedIndexChanged.
         * Descripcion: Evento al hacer clic en el botón para mostrar todas las reservas.
         * Entradas: objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * ********************************************************
        private void buttonMostrarTodo_Click(object sender, EventArgs e)
        {
            ActualizarDataViewTodo();
        }

        /// <summary>
        /// Evento al hacer clic en el botón de cancelar reserva (solicitud).
        /// </summary>
        private void BtEliminar_Click(object sender, EventArgs e)
        {
            if (!(DataViewReservas.SelectedRows.Count == 1))
            {
                MessageBox.Show("Para realizar esta acción debe seleccionar UNA reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idReserva = (int)DataViewReservas.SelectedRows[0].Cells[0].Value;
            SolicitarCancelacion(idReserva);
            ActualizarDataViewTodo();
        }

        /// <summary>
        /// Solicita la cancelación de una reserva.
        /// </summary>
        /// <param name="numeroReserva">Número de la reserva</param>
        public void SolicitarCancelacion(int numeroReserva)
        {
            try
            {
                conexion.abrir();
                string query =
                    "UPDATE Reservas " +
                    "SET cancelacionPendiente = 1, " +
                    "fechaCancelacion = @fechaActual " +
                    "WHERE numeroReserva = @numeroReserva";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                command.Parameters.AddWithValue("@fechaActual", DateTime.Now);
                command.Parameters.AddWithValue("@numeroReserva", numeroReserva);
                command.ExecuteNonQuery();
                MessageBox.Show("La cancelacion ya esta en proceso, un administrador deberá cofirmarla", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al solicitar la cancelacion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Confirma la cancelación de una reserva.
        /// </summary>
        /// <param name="idReserva">ID de la reserva</param>
        private void ConfirmarCancelacion(int idReserva)
        {
            try
            {
                conexion.abrir();
                // borrar reservas de habitaciones individuales
                string query =
                    "DELETE FROM ReservasHabitacion " +
                    "WHERE numeroReserva = @numeroReserva";
                SqlCommand command = new SqlCommand(query, conexion.ConectarBD);
                command.Parameters.AddWithValue("@fechaActual", DateTime.Now);
                command.Parameters.AddWithValue("@numeroReserva", idReserva);
                command.ExecuteNonQuery();

                // borrar reserva principal
                string query2 =
                    "DELETE FROM Reservas " +
                    "WHERE numeroReserva = @numeroReserva";
                SqlCommand command2 = new SqlCommand(query2, conexion.ConectarBD);
                command2.Parameters.AddWithValue("@fechaActual", DateTime.Now);
                command2.Parameters.AddWithValue("@numeroReserva", idReserva);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al solicitar la cancelacion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento al hacer clic en el botón de confirmar cancelación.
        /// </summary>
        private void buttonConfirmarCancelacion_Click(object sender, EventArgs e)
        {
            if (!(DataViewReservas.SelectedRows.Count == 1))
            {
                MessageBox.Show("Para realizar esta acción debe seleccionar UNA reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idReserva = (int)DataViewReservas.SelectedRows[0].Cells[0].Value;
            DialogResult result = MessageBox.Show("¿Estás seguro de que desea cancelar esta reserva (se eliminaran todos sus datos)?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Comprobar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                ConfirmarCancelacion(idReserva);
                ActualizarDataViewCancelaciones();
                ActualizarHabitacionesDisponibles();
            }
        }

        /// <summary>
        /// Evento al cargar el formulario de reservas.
        /// </summary>
        private void ReservasForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento al hacer clic en el botón de filtro de cancelaciones.
        /// </summary>
        private void buttonFiltroCancelaciones_Click(object sender, EventArgs e)
        {
            ActualizarDataViewCancelaciones();
        }
    }
}
