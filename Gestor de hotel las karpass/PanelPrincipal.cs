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
    public partial class PanelPrincipal : Form
    {
        // Variable para almacenar el último botón presionado
        private Button ultimoBoton = null;
        private ConexionBD conexion;
        private FuncionesAux funcionesAux;
        private int idEmpleado;

        /*******************************************************
        * Nombre: PanelInicioSesion
        * Descripcion: almacena un objeto de tipo ConexionBD y inicializa la ventana.
        * Entradas: 
        * Salidad: 
        * *******************************************************/
        public PanelPrincipal(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);

            int idRol = funcionesAux.ObtenerIdRol(idEmpleado); 
            
            if (idRol != 1) { BtPersonal.Visible = false; }
        }

        /*******************************************************
        * Nombre: CambiarColorBoton
        * Descripcion: Función para cambiar el color del botón y restaurar el color del último botón presionado.
        * Entradas: objeto (Button) el cual es precionado.
        * Salidad: 
        * *******************************************************/
        private void CambiarColorBoton(Button botonPresionado)
        {
            if (ultimoBoton != null)
            {
                ultimoBoton.BackColor = Color.PapayaWhip; // Restaurar color del último botón
            }

            botonPresionado.BackColor = Color.Orange; // Cambiar color del botón presionado
            ultimoBoton = botonPresionado; // Actualizar el último botón presionado
        }

        /*******************************************************
        * Nombre: BtCliente_Click
        * Descripcion: Llama una funcion para cambiar el color de un boton.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void BtCliente_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtCliente);

            cargarForm(new ClientesForm(idEmpleado));
        }

        /*******************************************************
        * Nombre: BtReservas_Click
        * Descripcion: Llama una funcion para cambiar el color de un boton.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void BtReservas_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReservas);

            cargarForm(new ReservasForm(idEmpleado));
        }

        /*******************************************************
        * Nombre: BtReportería_Click
        * Descripcion: Llama una funcion para cambiar el color de un boton.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void BtReportería_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReportería);

            cargarForm(new ReporteriaForm());
        }

        /*******************************************************
        * Nombre: BtPersonal_Click
        * Descripcion: Llama una funcion para cambiar el color de un boton.
        * Entradas: objeto (object) en el cual se va realizar el evento 
        * y el evento a realizar en el (EventArgs).
        * Salidad: 
        * *******************************************************/
        private void BtPersonal_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtPersonal);
            
            cargarForm(new PersonalForm());
        }

        /*******************************************************
        * Nombre: BtPersonal_Click
        * Descripcion: Función para cargar los Forms (los sub-menus) y colocarlos en el PanelAreaDeTrabajo
        * También remueve lo que estaba antes en el panel.
        * Entradas: objeto (object) Form a cargar.
        * Salidad: 
        * *******************************************************/
        public void cargarForm(object Form)
        {
            if (this.PanelAreaDeTrabajo.Controls.Count > 0)
                this.PanelAreaDeTrabajo.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.PanelAreaDeTrabajo.Controls.Add(f);
            this.PanelAreaDeTrabajo.Tag = f;
            f.Show();
        }
    }
}
