using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public ReservasForm(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            conexion = new ConexionBD();
            funcionesAux = new FuncionesAux(conexion);
        }
    }
}
