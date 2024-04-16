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

        /*******************************************************
        * Nombre: ConexionBD
        * Descripcion: Clase que crea un objeto de conexion con la base de datos.
        * Entradas:
        * Salidad:
        * *******************************************************/
        public ConexionBD()
        {
            ConectarBD.ConnectionString = cadena;
            ConectarBD2.ConnectionString = cadena;
        }

        /*******************************************************
        * Nombre: abrir
        * Descripcion: Inicia una conexion con la base de datos.
        * Entradas:
        * Salidad:
        * *******************************************************/
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

        /*******************************************************
        * Nombre: obtenerConexion
        * Descripcion: Devuelve un objeto de conexion con la BD.
        * Entradas:
        * Salidad:(SqlConnection) objeto de conexion con la bd.
        * *******************************************************/
        public static SqlConnection obtenerConexion()
        {
            string cadena = $"Data Source={Environment.MachineName};Initial Catalog=hotel; Integrated Security=True";
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

        /*******************************************************
        * Nombre: cerrar
        * Descripcion: Cierra una conexion con la base de datos.
        * Entradas:
        * Salidad:
        * *******************************************************/
        public void cerrar() 
        {
            ConectarBD.Close();
        }
    }
}
