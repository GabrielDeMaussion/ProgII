﻿using System;
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
using Clase_15._08__CarpinteriaApp_.Datos;

namespace Clase_15._08__CarpinteriaApp_.Presentacion
{
    public partial class FrmNuevoPresupuesto : Form
    {
        DBHelper gestor = null;
        Presupuesto nuevo = null;
        public FrmNuevoPresupuesto()
        {
            InitializeComponent();
            nuevo = new Presupuesto(); 
            gestor= new DBHelper();
        }

        private void NuevoPresupuesto_Load(object sender, EventArgs e)
        {
            //Precarga de textos
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            lblPresupuestoNro.Text = lblPresupuestoNro.Text + " " + (gestor.ProximoPresupuesto()).ToString();


            //Ejecucion de metodos en orden
            gestor.ProximoPresupuesto();
            CargarProducto();
        }

        

        //Metodos del formulario
        private void CargarProducto()
        {
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_PRODUCTOS");

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validacion
            if (string.IsNullOrEmpty(txtCliente.Text) )
            {
                MessageBox.Show("Debe ingresar un cliente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            



            //Confirmacion de el grabado
            GrabarPresupuesto();

        }

        private void GrabarPresupuesto()
        {
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToInt32(txtDescuento.Text);

            if (gestor.ConfirmarPresupuesto(nuevo))
            {
                MessageBox.Show("Se cargo con exito el presupuesto", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al cargar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
