using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_hotel_las_karpass
{
    internal static class Program
    {
        /*******************************************************
        * Nombre: Main
        * Descripcion: Punto de entrada principal para la aplicación.
        * Entradas: 
        * Salidad: 
        * *******************************************************/
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PanelInicioSesion());
        }
    }
}
