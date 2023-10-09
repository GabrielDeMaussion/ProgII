using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VeterinariaApp.Datos
{
    internal class DBHelper
    {
        //Atributos
        // ================================================================================================================================= //
        private SqlConnection conexion;
        private static DBHelper instancia;
        // ================================================================================================================================= //



        //Constructor e instancia
        // ================================================================================================================================= //
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


        //Genera una instancia del helper para facilitar su acceso y mantener consistencia con e manejo de datos (Singleton)
        public static DBHelper ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new DBHelper();
            return instancia;
        }
        // ================================================================================================================================= //



        //Metodos
        // ================================================================================================================================= //
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


        //
        public void CargarCombo(ComboBox Combo, string NombreSP)
        {
            //Limpiar el combo y cargar los datos de la consulta en una tabla
            Combo.Items.Clear();
            DataTable tabla = ConsultarSP(NombreSP);

            //Asignar valores de la tabla al combo
            Combo.DataSource = tabla;
            Combo.ValueMember = tabla.Columns[0].ColumnName;
            Combo.DisplayMember = tabla.Columns[1].ColumnName;

            //Formateo del combo
            Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            Combo.SelectedIndex = -1;
        }


        //
        public void CargarGrilla(DataGridView grilla, List<Parametros> lista, string NombreSP)
        {
            DataTable tabla = ConsultarSP(NombreSP, lista); // Tabla de a base de datos
            foreach (DataRow fila in tabla.Rows)
            {
                List<string> valores = new List<string>();

                foreach (DataGridViewColumn columna in grilla.Columns)
                {
                    string valor = fila[columna.HeaderText].ToString();
                    valores.Add(valor);
                }

                grilla.Rows.Add(valores.ToArray());
            }


        }


        // ================================================================================================================================= //











    }
}
