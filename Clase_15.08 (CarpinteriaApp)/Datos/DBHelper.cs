using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_15._08__CarpinteriaApp_.Entidades;

namespace Clase_15._08__CarpinteriaApp_.Datos
{
    internal class DBHelper
    {
        private SqlConnection conexion;

        public DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1");
        }


        public int ProximoPresupuesto()
        {
            //SqlConnection conexion = new SqlConnection(); //172.16.10.196  alumnolab1  alumno1w1 ||| Esto se movio para arriba, al contructor de la clase al usar una sola conexion en todo el proyecto
            //conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PROXIMO_ID";

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@next";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();


            conexion.Close();

            return Convert.ToInt32(parametro.Value);
        }


        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        public bool ConfirmarPresupuesto(Presupuesto presupuesto)
        {
            bool resultado = true;

            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INSERTAR_MAESTRO";


            return resultado;
        }

    }
}
