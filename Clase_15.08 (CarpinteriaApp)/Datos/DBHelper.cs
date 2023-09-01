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

            SqlTransaction t = null;
            try {
            conexion.Open();

            //creacion y seleccion y tipo de comando que va a llegar a SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.Transaction = t;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_INSERTAR_MAESTRO";

            //Agregado de parametros al comando que llega con el SP
            comando.Parameters.AddWithValue("@cliente", presupuesto.Cliente);
            comando.Parameters.AddWithValue("@descuento", presupuesto.Descuento);
            comando.Parameters.AddWithValue("@total", presupuesto.CalcularTotal().ToString());

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@presupuesto_nro";
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametro);

            comando.ExecuteNonQuery();

            int presupuestoNro = (int)parametro.Value;
            int DetalleNro = 1;

            SqlCommand cmdDetalle;
            cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
            cmdDetalle.CommandType = CommandType.StoredProcedure;

            foreach (DetallePresupuesto detalle in presupuesto.Detalles)
            {
                cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                cmdDetalle.Parameters.AddWithValue("@detalle", DetalleNro);
                cmdDetalle.Parameters.AddWithValue("@id_producto", detalle.Producto.ProductoNro);
                cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                cmdDetalle.ExecuteNonQuery();
                DetalleNro += 1;

            }

            t.Commit();

            }catch(Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally 
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return resultado;
        }

    }
}
