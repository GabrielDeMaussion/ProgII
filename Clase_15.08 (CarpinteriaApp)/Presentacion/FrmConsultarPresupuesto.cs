using Clase_15._08__CarpinteriaApp_.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_15._08__CarpinteriaApp_.Presentacion
{
    public partial class FrmConsultarPresupuesto : Form
    {
        DBHelper helper;
        public FrmConsultarPresupuesto()
        {
            InitializeComponent();
            helper = new DBHelper();
        }

        private void FrmConsultarPresupuesto_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Now.AddDays(-7);
            dtpFechaHasta.Value = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Validar datos antes de la consulta
            List<Parametros> lista = new List<Parametros>();
            lista.Add(new Parametros(@"fecha_desde", dtpFechaDesde.Value.ToString("yyyyMMdd")));
            lista.Add(new Parametros(@"fecha_hasta", dtpFechaHasta.Value.ToString("yyyyMMdd")));
            lista.Add(new Parametros(@"cliente", txtCliente.Text));

            DataTable tabla = helper.Consultar("SP_CONSULTAR_PRESUPUESTOS", lista);
            dgvPresupuestos.Rows.Clear();

            foreach(DataRow fila in tabla.Rows)
            {
                dgvPresupuestos.Rows.Add(new object[]
                {
                    fila["presupuesto_nro"].ToString(),
                    fila["fecha"].ToString(),
                    fila["cliente"].ToString(),
                    fila["total"].ToString()
                });
            }
        }
    }
}
