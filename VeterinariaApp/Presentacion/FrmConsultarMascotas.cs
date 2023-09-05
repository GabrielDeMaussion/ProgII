using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaApp.Datos;

namespace VeterinariaApp.Presentacion
{
    public partial class FrmConsultarMascotas : Form
    {
        DBHelper dbHelper = new DBHelper();

        public FrmConsultarMascotas()
        {
            InitializeComponent();
        }

        private void FrmConsultarMascotas_Load(object sender, EventArgs e)
        {
            cboTipo.Items.Clear();
            dbHelper.CargarCombo(cboTipo, "SP_Consultar_Tipos");
        }


        //Eventos
        // ================================================================================================================================= //
        //Evento al tocar booton de fitrar para cargar todas las mascotas
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Parametros> lista = new List<Parametros>();

            if (txtNombre.Text != "")
            {
                lista.Add(new Parametros("@nombre", txtNombre.Text));
            }
            if (cboTipo.SelectedItem.ToString() != "") 
            {
                lista.Add(new Parametros("@tipo", cboTipo.SelectedItem.ToString()));
            }
            if (txtEdad.Text != "")
            {
                lista.Add(new Parametros("@nombre", txtEdad.Text));
            }




            dbHelper.CargarGrilla(dgvMascotas, lista, @"SP_Consultar_Mascotas");
        }
        // ================================================================================================================================= //
    }
}
