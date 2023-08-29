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
using Clase_15._08__CarpinteriaApp_.Entidades;

namespace Clase_15._08__CarpinteriaApp_.Presentacion
{
    public partial class NuevoPresupuesto : Form
    {
        Presupuesto nuevo = null;
        public NuevoPresupuesto()
        {
            InitializeComponent();
            nuevo = new Presupuesto(); 
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
            cboProducto.DisplayMember = tabla.Columns[1].ColumnName;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validaciones para evitar errores (se puede hacer mejor y mas corto)
            if(cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if ((txtCantidad.Text is null) || !(int.TryParse(txtCantidad.Text, out _)))
            {
                MessageBox.Show("Ingrese una cantidad valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow prod in dgvDetalles.Rows)
            {
                if (prod.Cells["ColProducto"].Value.ToString() == cboProducto.Text)
                {
                    MessageBox.Show("Este producto ya esta presupuestado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            //Traer los datos del producto del combo a valores manejables por C#
            DataRowView item = (DataRowView)cboProducto.SelectedItem;
            int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            string nombre = item.Row.ItemArray[1].ToString();
            double precio = Convert.ToDouble(item.Row.ItemArray[2]);

            //Asignar los valores de C# a un objeto tipo Producto
            Producto productoNuevo = new Producto(nro, nombre, precio);

            //Tomar la cantidad relacionada al producto para crear un detalle
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            DetallePresupuesto detalle = new DetallePresupuesto(productoNuevo, cantidad);

            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { detalle.Producto.ProductoNro, 
                                                detalle.Producto.Nombre,
                                                detalle.Producto.Precio,
                                                detalle.Cantidad,
                                                "Quitar"});

            CalcularTotales();

        }

        private void CalcularTotales()
        {
            txtSubTotal.Text = nuevo.CalcularTotal().ToString();
            if (!string.IsNullOrEmpty(txtDescuento.Text))
            {
                double desc = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text);
                txtTotal.Text = (nuevo.CalcularTotal() - desc).ToString();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4) 
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
