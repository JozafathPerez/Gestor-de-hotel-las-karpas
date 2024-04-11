using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestor_de_hotel_las_karpass
{
    internal class FuncionesAux
    {
        private ConexionBD conexion;

        public FuncionesAux(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public int ObtenerIdRol(int idEmpleado)
        {
            // Verifica si el idEmpleado es igual a 1 para administrador
            string query = "SELECT idRol FROM Empleados WHERE idEmpleado = @idEmpleado";

            using (SqlCommand command = new SqlCommand(query, conexion.ConectarBD))
            {
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                conexion.abrir();

                try
                {
                    return (int)command.ExecuteScalar();
                }
                finally
                {
                    conexion.cerrar();
                }
            }
        }

        // Remueve cualquier caracter de un string que no sea un numero o un punto
        public string RemoverCaracteresNoNumericos(string input)
        {
            Regex regex = new Regex("[^0-9.]");
            string resultado = regex.Replace(input, "");
            return resultado;
        }







    }
}
