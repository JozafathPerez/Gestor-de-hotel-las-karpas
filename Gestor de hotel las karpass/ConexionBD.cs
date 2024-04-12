using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestor_de_hotel_las_karpass
{
    public class ConexionBD
    {
        string cadena = "Data source=" + Environment.MachineName + "; Initial Catalog=hotel; Integrated Security=True";

        public SqlConnection ConectarBD = new SqlConnection();
        public static SqlConnection ConectarBD2 = new SqlConnection();

        public ConexionBD()
        {
            ConectarBD.ConnectionString = cadena;
            ConectarBD2.ConnectionString = cadena;
        }

        public void  abrir()
        {
            try
            {
                ConectarBD.Open();
                Console.WriteLine("Conexion abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: No se pudo abrir la BD" + ex.Message);
            }
        }
        public static SqlConnection obtenerConexion()
        {
            string cadena = "Data Source=LAPTOP-N2TOVTOC;Initial Catalog=hotel; Integrated Security=True";
            SqlConnection conectarBD = new SqlConnection();
            conectarBD.ConnectionString = cadena;
            try
            {
                conectarBD.Open();
                return conectarBD;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Logro " + ex.Message);
                return null;
            }
        }

        public void cerrar() 
        {
            ConectarBD.Close();
        }
    }
}
