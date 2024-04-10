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

        public PanelPrincipal(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);

            int idRol = funcionesAux.ObtenerIdRol(idEmpleado); // Como puedo hacer esto
            
            if (idRol != 1)
            {
                BtPersonal.Visible = false;
            }
        }

        // Función para cambiar el color del botón y restaurar el color del último botón presionado
        private void CambiarColorBoton(Button botonPresionado)
        {
            if (ultimoBoton != null)
            {
                ultimoBoton.BackColor = Color.PapayaWhip; // Restaurar color del último botón
            }

            botonPresionado.BackColor = Color.Orange; // Cambiar color del botón presionado
            ultimoBoton = botonPresionado; // Actualizar el último botón presionado
        }

        private void BtCliente_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtCliente);

            cargarForm(new ClientesForm(idEmpleado));
        }

        private void BtReservas_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReservas);

            cargarForm(new ReservasForm(idEmpleado));
        }

        private void BtReportería_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtReportería);

            cargarForm(new ReporteriaForm(idEmpleado));
        }

        private void BtPersonal_Click(object sender, EventArgs e)
        {
            CambiarColorBoton(BtPersonal);
            
            cargarForm(new PersonalForm(idEmpleado));
        }

        // Función para cargar los Forms (los sub-menus) y colocarlos en el PanelAreaDeTrabajo
        // También remueve lo que estaba antes en el panel!!
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
