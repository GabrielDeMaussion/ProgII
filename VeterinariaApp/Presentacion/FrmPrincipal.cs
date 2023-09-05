using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaApp.Presentacion;

namespace VeterinariaApp
{
    public partial class FrmPrincipal : Form
    {
        //Instancia de todos los formuarios para manejo de datos ENTRE todos los formuarios
        FrmConsultarMascotas frmConsultarMascotas = new FrmConsultarMascotas();




        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }


        //Metodos

        private void CambiarFormulario(Form Formulario)
        {
            //Limpia el panel si hay algun contenido
            PanelContenido.Controls.Clear();

            //Establece el formulario secundario en el panel
            Formulario.TopLevel = false;
            PanelContenido.Controls.Add(Formulario);
            Formulario.Dock = DockStyle.Fill;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Show();
        }

        //Metodo para cambiar entre formularios manteniendo ciertas propiedades (esto es gusto personal y testeo)
        //===========================================================================================================
        //private void CambiarFormulario(Form Formulario)
        //{
        //    this.Hide();

        //    Formulario.StartPosition = FormStartPosition.Manual;
        //    Formulario.Location = this.Location;
        //    Formulario.ShowDialog();

        //    this.Location = Formulario.Location;
        //    this.Show();
        //}
        //===========================================================================================================

        private void TSMConsutarMascotas_Click(object sender, EventArgs e)
        {
            CambiarFormulario(frmConsultarMascotas);
        }
    }
}
