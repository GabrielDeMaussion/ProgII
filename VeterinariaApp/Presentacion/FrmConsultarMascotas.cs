using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaApp.Datos;

namespace VeterinariaApp.Presentacion
{
    public partial class FrmConsultarMascotas : Form
    {

        public FrmConsultarMascotas()
        {
            InitializeComponent();
        }

        private void FrmConsultarMascotas_Load(object sender, EventArgs e)
        {
            cboTipo.Items.Clear();
            DBHelper.ObtenerInstancia().CargarCombo(cboTipo, "SP_Consultar_Tipos");

        }

        //Metodos
        // ================================================================================================================================= //



        // ================================================================================================================================= //


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
            if (cboTipo.SelectedItem != null) 
            {
                lista.Add(new Parametros("@tipo", cboTipo.SelectedItem.ToString()));
            }
            if (txtEdad.Text != "")
            {
                lista.Add(new Parametros("@nombre", txtEdad.Text));
            }




            DBHelper.ObtenerInstancia().CargarGrilla(dgvMascotas, lista, @"SP_Consultar_Mascotas");
        }
        // ================================================================================================================================= //
    }
}
