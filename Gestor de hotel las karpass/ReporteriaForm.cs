using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestor_de_hotel_las_karpass
{
    public partial class ReporteriaForm : Form
    {
        /*******************************************************
         * Nombre: ReporteriaForm.
         * Descripcion: Funcion que inicializa la ventana.
         * Entradas:
         * Salidad:
         * *******************************************************/
        public ReporteriaForm()
        {
            InitializeComponent();
        }

        /*******************************************************
         * Nombre: obtenerReservas.
         * Descripcion: Funcion la cual se conecta a la base de datos, saca la informacion de todas las reservas
         * almacenadas y la guarda en un arreglo.
         * Entradas:
         * Salidad: Devuelve una lista de listas de tipo string con la informacion de todas las reservas
         * en la base de datos.
         * *******************************************************/
        public List<List<string>> obtenerReservas()
        {
            List<List<string>> listaReservas = new List<List<string>>();

            using (SqlConnection conexion = ConexionBD.obtenerConexion())
            {
                string query = "SELECT numeroReserva,identificacionCliente,inicioReserva,finReserva," +
                    "cantPersonas,fechaCancelacion,costoTotal,idEmpleado,cancelacionPendiente FROM hotel.dbo.Reservas";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                int contador = 0;
                while (lector.Read())
                {
                    List<string> reservaActual = new List<string>();
                    reservaActual.Add(lector.GetInt32(0).ToString());
                    reservaActual.Add(lector[1].ToString());
                    reservaActual.Add(lector.GetDateTime(2).ToString());
                    reservaActual.Add(lector.GetDateTime(3).ToString());
                    reservaActual.Add(lector.GetInt32(4).ToString());
                    reservaActual.Add(lector[5].ToString());
                    reservaActual.Add(lector.GetDecimal(6).ToString());
                    reservaActual.Add(lector.GetInt32(7).ToString());
                    reservaActual.Add(lector[8].ToString());
                    listaReservas.Add(reservaActual);
                }
                conexion.Close();
            }
            return listaReservas;
        }

         /*******************************************************
         * Nombre: obtenerCliente.
         * Descripcion: Funcion la cual se conecta a la base de datos, saca la informacion de todas los clientes
         * almacenados y la guarda en un arreglo.
         * Entradas:
         * Salidad: Devuelve una lista de listas de tipo string con la informacion de todas los clientes
         * en la base de datos.
         * *******************************************************/
        public List<List<string>> obtenerCliente()
        {
            List<List<string>> listaClientes = new List<List<string>>();

            using (SqlConnection conexion = ConexionBD.obtenerConexion())
            {
                string query = "SELECT identificacionCliente,nombre,primerApellido,segundoApellido," +
                    "paisProcedencia,telefono,correo FROM Clientes";

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    List<string> clienteActual = new List<string>();
                    clienteActual.Add(lector[0].ToString());
                    clienteActual.Add(lector.GetString(1));
                    clienteActual.Add(lector.GetString(2));
                    clienteActual.Add(lector.GetString(3));
                    clienteActual.Add(lector.GetString(4));
                    clienteActual.Add(lector.GetDecimal(5).ToString());
                    clienteActual.Add(lector.GetString(6));
                    listaClientes.Add(clienteActual);
                }
                conexion.Close();
            }
            return listaClientes;
        }

        /*******************************************************
         * Nombre: obtenerEmpleado.
         * Descripcion: Funcion la cual se conecta a la base de datos, saca la informacion de todas los empleados
         * almacenados y la guarda en un arreglo.
         * Entradas:
         * Salidad: Devuelve una lista de listas de tipo string con la informacion de todas los empleados
         * en la base de datos.
         * *******************************************************/
        public List<List<string>> obtenerEmpleado()
        {
            List<List<string>> listaEmpleados = new List<List<string>>();

            using (SqlConnection conexion = ConexionBD.obtenerConexion())
            {
                string query = "SELECT idEmpleado,nombre,primerApellido,segundoApellido," +
                    "idRol,ultimaModificacion,fechaCreacion FROM hotel.dbo.Empleados";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                int contador = 0;
                while (lector.Read())
                {
                    List<string> empleadoActual = new List<string>();
                    empleadoActual.Add(lector.GetInt32(0).ToString());
                    empleadoActual.Add(lector.GetString(1));
                    empleadoActual.Add(lector.GetString(2));
                    empleadoActual.Add(lector.GetString(3));
                    empleadoActual.Add(lector.GetInt32(4).ToString());
                    empleadoActual.Add(lector.GetDateTime(5).ToString());
                    empleadoActual.Add(lector.GetDateTime(6).ToString());
                    listaEmpleados.Add(empleadoActual);
                }
                conexion.Close();
            }
            return listaEmpleados;
        }

        /*******************************************************
         * Nombre: ReporteriaForm_Load
         * Descripcion: Funcion que oculta el grafico y la tabla al momento que la ventana es inicializada.
         * Entradas: un objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void ReporteriaForm_Load(object sender, EventArgs e)
        {
            grid.Visible = false;
            grafico.Visible = false;
        }

        /*******************************************************
         * Nombre: BtReservas_Click
         * Descripcion: Funcion que almacena la informacion de una o varias reservas para mostrarla 
         * de forma grafica en una tabla.
         * Entradas: un objeto (object) en el cual se va realizar el evento 
         * y el evento a realizar en el (EventArgs).
         * Salidad:
         * *******************************************************/
        private void BtReservas_Click(object sender, EventArgs e)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            grafico.Visible = false;
            grid.Columns.Add("Numero Reserva", "Numero Reserva");
            grid.Columns.Add("Id Cliente", "Id Cliente");
            grid.Columns.Add("Nombre Cliente", "Nombre Cliente");
            grid.Columns.Add("Primer Apellido", "Primer Apellido");
            grid.Columns.Add("Segundo Apellido", "Segundo Apellido");
            grid.Columns.Add("Pais Procedencia", "Pais Procedencia");
            grid.Columns.Add("Cant Personas", "Cant Personas");
            grid.Columns.Add("Inicio Reserva", "Inicio Reserva");
            grid.Columns.Add("Fin Reserva", "Fin Reserva");
            grid.Columns.Add("Costo Total", "Costo Total");
            grid.Columns.Add("Id Recepcionista", "Id Recepcionista");
            grid.Columns.Add("Estado Reserva", "Estado Reserva");
            List<List<string>> clientes = obtenerCliente();
            List<List<string>> reservas = obtenerReservas();

            for (int i = 0; i < clientes.Count; i++)
            {
                List<string> clienteActual = clientes[i];
                for (int j = 0; j < reservas.Count; j++)
                {
                    List<string> reservaActual = reservas[j];
                    if (clienteActual[0] == reservaActual[1])
                    {
                        string estado;
                        if (reservaActual[8] == "0") { estado = "Vigente"; } else { estado = "Cancelado"; }
                        grid.Rows.Add(reservaActual[0], reservaActual[1], clienteActual[1], clienteActual[2], clienteActual[3],
                clienteActual[4], reservaActual[4], reservaActual[2], reservaActual[3], reservaActual[6], reservaActual[7],
                estado);
                    }
                }
            }
            grid.Visible = true;
        }

        /*******************************************************
        * Nombre: btCancelaciones_Click
        * Descripcion: Funcion que almacena la informacion de una o varias reservas que hayan sido canceladas
        * para mostrarla de forma grafica en una tabla.
        * Entradas: un objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad:
        * *******************************************************/
        private void btCancelaciones_Click(object sender, EventArgs e)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            grafico.Visible = false;
            grid.Columns.Add("Numero Reserva", "Numero Reserva");
            grid.Columns.Add("Id Recepcionista", "Id Recepcionista");
            grid.Columns.Add("Id Cliente", "Id Cliente");
            grid.Columns.Add("Nombre Cliente", "Nombre Cliente");
            grid.Columns.Add("Primer Apellido", "Primer Apellido");
            grid.Columns.Add("Segundo Apellido", "Segundo Apellido");
            grid.Columns.Add("Estado Reserva", "Estado Reserva");
            List<List<string>> clientes = obtenerCliente();
            List<List<string>> reservas = obtenerReservas();

            for (int i = 0; i < clientes.Count; i++)
            {
                List<string> clienteActual = clientes[i];
                for (int j = 0; j < reservas.Count; j++)
                {
                    List<string> reservaActual = reservas[j];
                    if (clienteActual[0] == reservaActual[1])

                    {
                        if (reservaActual[8] != "0") {
                            grid.Rows.Add(reservaActual[0], reservaActual[7], reservaActual[1], clienteActual[1], clienteActual[2],
                            clienteActual[3], "Cancelado");
                        }
                    }
                }
            }
            grid.Visible = true;
        }

        /*******************************************************
        * Nombre: btClientesRe_Click
        * Descripcion: Funcion la cual busca en la BD las nacionalidades de todos los clientes y 
        * las compara por medio de un grafico.
        * Entradas: un objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad:
        * *******************************************************/
        private void btClientesRe_Click(object sender, EventArgs e)
        {
            grid.Visible = false;
            grafico.Series.Clear();
            Dictionary<string, int> clientePais = new Dictionary<string, int>();
            List<List<string>> clientes = obtenerCliente();
            for (int i = 0; i < clientes.Count; i++)
            {
                List<string> clienteActual = clientes[i];
                if (clientePais.ContainsKey(clienteActual[4]))
                {
                    clientePais[clienteActual[4]]++;
                }
                else
                {
                    clientePais.Add(clienteActual[4], 1);
                }
            }
            Series nuevaSerie = new Series("Clientes por país");
            nuevaSerie.ChartType = SeriesChartType.Pie;

            foreach (var llave in clientePais)
            {
                string nombre = llave.Key;
                int valor = llave.Value;

                nombre += " ( " + valor.ToString() + " Clientes )";

                nuevaSerie.Points.AddXY(nombre, valor);
            }
            grafico.Series.Add(nuevaSerie);
            grafico.Visible = true;
        }

        /*******************************************************
        * Nombre: obtenerNombreRe
        * Descripcion: Funcion la cual recibe el id de un empleado y devuelve su nombre.
        * Entradas: (string) id del empleado a buscar.
        * Salidad:
        * *******************************************************/
        public string obtenerNombreRe(string id)
        {
            List<List<string>> empleados = obtenerEmpleado();
            for (int i = 0; i < empleados.Count; i++)
            {
                List<string> empleadoActual = empleados[i];
                if (empleadoActual[0] == id)
                {
                    return empleadoActual[1];
                }
            }
            return null;
        }

        /*******************************************************
        * Nombre: obtenerNombreCl
        * Descripcion: Funcion la cual recibe el id de un cliente y devuelve su nombre.
        * Entradas: (string) id del cliente a buscar.
        * Salidad:
        * *******************************************************/
        public string obtenerNombreCl(string id)
        {
            List<List<string>> clientes = obtenerCliente();
            for (int i = 0; i < clientes.Count; i++)
            {
                List<string> clienteActual = clientes[i];
                if (clienteActual[0] == id)
                {
                    return clienteActual[1];
                }
            }
            return null;
        }

        /*******************************************************
        * Nombre: btRecepcionista_Click
        * Descripcion: Funcion la cual busca en la BD las reservas de todos los empleados y 
        * las compara por medio de un grafico para ver quien ha realizado mas de estas.
        * Entradas: un objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad:
        * *******************************************************/
        private void btRecepcionista_Click(object sender, EventArgs e)
        {
            grid.Visible = false;
            grafico.Series.Clear();
            Dictionary<string, int> empleadoReserva = new Dictionary<string, int>();
            List<List<string>> reservas = obtenerReservas();
            for (int i = 0; i < reservas.Count; i++)
            {
                List<string> empleadoActual = reservas[i];
                string nombreActual = obtenerNombreRe(empleadoActual[7]);
                if (empleadoReserva.ContainsKey(nombreActual))
                {
                    empleadoReserva[nombreActual]++;
                }
                else
                {
                    empleadoReserva.Add(nombreActual, 1);
                }
            }

            Series nuevaSerie = new Series("Empleados con mas reservas");
            nuevaSerie.ChartType = SeriesChartType.Pie;

            foreach (var llave in empleadoReserva)
            {
                string nombre = llave.Key;
                int valor = llave.Value;

                nombre += " ( " + valor.ToString() + " Reservas )";

                nuevaSerie.Points.AddXY(nombre, valor);
            }
            grafico.Series.Add(nuevaSerie);
            grafico.Visible = true;
        }

        /*******************************************************
        * Nombre: btFechasRe_Click
        * Descripcion: Funcion la cual busca en la BD las reservas y 
        * las compara por medio de un grafico para ver cuantas de estas se han realizado en rangos de 3 meses.
        * Entradas: un objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad:
        * *******************************************************/
        private void btFechasRe_Click(object sender, EventArgs e)
        {
            grid.Visible = false;
            grafico.Series.Clear();
            Dictionary<DateTime, int> reservasPorRango = new Dictionary<DateTime, int>();
            DateTime fechaInicio = new DateTime(2022, 1, 1);
            DateTime fechaActual = DateTime.Today;
            TimeSpan intervalo = TimeSpan.FromDays(90);

            DateTime fechaFin = fechaInicio.Add(intervalo);
            List<List<string>> reservas = obtenerReservas();
            int cont = 0;
            while (fechaFin <= fechaActual)
            {
                for (int i = 0; i < reservas.Count; i++)
                {
                    List<string> reservaActual = reservas[i];
                    if (DateTime.Parse(reservaActual[2]) >= fechaInicio && DateTime.Parse(reservaActual[2]) < fechaFin)
                    {
                        cont++;
                    }
                }
                reservasPorRango.Add(fechaInicio, cont);
                cont = 0;
                fechaInicio = fechaFin;
                fechaFin = fechaInicio.Add(intervalo);
            }

            Series nuevaSerie = new Series("Reservas en rangos de 3 meses");
            nuevaSerie.ChartType = SeriesChartType.Column;

            foreach (var llave in reservasPorRango)
            {
                string nombre = llave.Key.ToString();
                int valor = llave.Value;

                nuevaSerie.Points.AddXY(nombre, valor);
            }
            grafico.Series.Add(nuevaSerie);
            grafico.Visible = true;
        }

        /*******************************************************
        * Nombre: btIngresos_Click
        * Descripcion: Funcion la cual busca en la BD las reservas y 
        * las compara por medio de un grafico para ver cuantos ingresos se han generado en rangos de 3 meses.
        * Entradas: un objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad:
        * *******************************************************/
        private void btIngresos_Click(object sender, EventArgs e)
        {
            grid.Visible = false;
            grafico.Series.Clear();
            Dictionary<DateTime, decimal> ingresosPorRango = new Dictionary<DateTime, decimal>();
            DateTime fechaInicio = new DateTime(2022, 1, 1);
            DateTime fechaActual = DateTime.Today;
            TimeSpan intervalo = TimeSpan.FromDays(90);

            DateTime fechaFin = fechaInicio.Add(intervalo);
            List<List<string>> reservas = obtenerReservas();
            decimal monto = 0;
            while (fechaFin <= fechaActual)
            {
                for (int i = 0; i < reservas.Count; i++)
                {
                    List<string> reservaActual = reservas[i];
                    if (DateTime.Parse(reservaActual[2]) >= fechaInicio && DateTime.Parse(reservaActual[2]) < fechaFin)
                    {
                        monto += Decimal.Parse(reservaActual[6]);
                    }
                }
                ingresosPorRango.Add(fechaInicio, monto);
                monto = 0;
                fechaInicio = fechaFin;
                fechaFin = fechaInicio.Add(intervalo);
            }

            Series nuevaSerie = new Series("Ingresos totales por rangos de 3 meses");
            nuevaSerie.ChartType = SeriesChartType.Bar;

            foreach (var llave in ingresosPorRango)
            {
                string nombre = llave.Key.ToString();
                decimal valor = llave.Value;

                // DateTime fechafin = llave.Key;
                // nombre += " - " + fechafin.Add(intervalo).ToString() + " (" + valor.ToString() + ")";
                nuevaSerie.Points.AddXY(nombre, valor);
            }
            grafico.Series.Add(nuevaSerie);
            grafico.Visible = true;

        }

        /*******************************************************
        * Nombre: btClienteFre_Click
        * Descripcion: Funcion la cual busca en la BD las reservas y 
        * las compara por medio de un grafico para ver cual ha sido el cliente que
        * mas ha frecuentado el hotel.
        * Entradas: un objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad:
        * *******************************************************/
        private void btClienteFre_Click(object sender, EventArgs e)
        {
            grid.Visible = false;
            grafico.Series.Clear();
            Dictionary<string, int> clienteFrecuente = new Dictionary<string, int>();
            List<List<string>> reservas = obtenerReservas();
            for (int i = 0; i < reservas.Count; i++)
            {
                List<string> clienteActual = reservas[i];
                string nombreActual = obtenerNombreCl(clienteActual[1]);
                if (clienteFrecuente.ContainsKey(nombreActual))
                {
                    clienteFrecuente[nombreActual]++;
                }
                else
                {
                    clienteFrecuente.Add(nombreActual, 1);
                }
            }

            Series nuevaSerie = new Series("Clientes mas frecuentes");
            nuevaSerie.ChartType = SeriesChartType.Pie;

            foreach (var llave in clienteFrecuente)
            {
                string nombre = llave.Key;
                int valor = llave.Value;

                nombre += " ( " + valor.ToString() + " Reservaciones )";
                nuevaSerie.Points.AddXY(nombre, valor);
            }
            grafico.Series.Add(nuevaSerie);
            grafico.Visible = true;
        }

        private void grafico_Click(object sender, EventArgs e)
        {

        }
    }
}
