using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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








    }
}
