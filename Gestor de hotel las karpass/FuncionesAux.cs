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

        /*******************************************************
        * Nombre: FuncionesAux
        * Descripcion: almacena un objeto de tipo ConexionBD.
        * Entradas: (ConexionBD) objeto a almacenar.
        * Salidad: 
        * *******************************************************/
        public FuncionesAux(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        /*******************************************************
        * Nombre: ObtenerIdRol
        * Descripcion: Verifica si el idEmpleado es igual a 1 para administrador.
        * Entradas: (int) id empleado.
        * Salidad: (int) resultado del comando Sql.
        * *******************************************************/
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

        /*******************************************************
        * Nombre: RemoverCaracteresNoNumericos
        * Descripcion: Remueve cualquier caracter de un string que no sea un numero o un punto.
        * Entradas: (string) caracter a modificar.
        * Salidad: (string) caracter modificado.
        * *******************************************************/
        public string RemoverCaracteresNoNumericos(string input)
        {
            Regex regex = new Regex("[^0-9.]");
            string resultado = regex.Replace(input, "");
            return resultado;
        }
    }
}
