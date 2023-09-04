using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VeterinariaApp.Datos
{
    internal class DBHelper
    {
        //Atributos
        private SqlConnection conexion;

        //Constructor
        //(Mi opcion admite ingresar la cadena de conexion al instanciar "DBHelper", si no se ingresa nada, la cadena de conexion sera la mia por defecto)
        public DBHelper(SqlConnection Conexion = null) 
        {
            if (Conexion == null)
            {
                conexion = new SqlConnection(@"Data Source=GALER-PC\SQLEXPRESS;Initial Catalog=VeterinariaApp;Integrated Security=True");
            }
            else
            {
                conexion = Conexion;
            }
        }

        //Metodos

        //Consuta con o sin parametros a la base de datos por medio de procedimientos almacenados
        public DataTable ConsultarSP (string NombreSP = "", List<Parametros> Parametros = null)
        {
            //Iniciar a conexion
            conexion.Open();

            //Inicializar y asignar el tipo de comando a la conexion
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;

            //Recorrer y agregar tantos parametros como elementos de la lista al comando que ejecuta el SP si es que hay
            comando.Parameters.Clear();
            if (Parametros != null)
            {
                foreach (Parametros parametro in Parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                }
            }

            //Inicializar la tabla de retorno y cargar en ella los resultados de la consuta con el SP
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            //Cerrar la conexion
            conexion.Close();

            //Devolver la tabla como resutado de la consulta
            return tabla;
        }
















    }
}
