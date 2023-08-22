using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Clase_15._08__CarpinteriaApp_.Presentacion
{
    public partial class NuevoPresupuesto : Form
    {
        public NuevoPresupuesto()
        {
            InitializeComponent();
        }

        private void NuevoPresupuesto_Load(object sender, EventArgs e)
        {
            //Precarga de textos
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";

            //Ejecucion de metodos en orden
            ProximoPresupuesto();
            CargarProducto();
        }

        

        //Metodos del formulario
        private void ProximoPresupuesto()
        {
            SqlConnection conexion = new SqlConnection(); //172.16.10.196  alumnolab1  alumno1w1
            conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";
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
        }

        private void CargarProducto()
        {
            SqlConnection conexion = new SqlConnection(); //172.16.10.196  alumnolab1  alumno1w1
            conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_PRODUCTOS";

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();
            cboProducto.DataSource = tabla; 
            cboProducto.ValueMember = tabla.Columns[0].ColumnName;
            cboProducto.DisplayMember = tabla.Columns[0].ColumnName;
        }
    }
}
