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
using VeterinariaApp.Entidades;
using VeterinariaApp.Presentacion;

namespace VeterinariaApp
{
    public partial class FrmPrincipal : Form
    {
        //Instancias
        // ================================================================================================================================= //
        //Instancia de todos los formuarios y clases para manejo de datos ENTRE todos los formuarios:
        FrmConsultarMascotas frmConsultarMascotas = new FrmConsultarMascotas();
        FrmLogIn frmLogIn = new FrmLogIn();

        //Atributos estaticos
        static FrmPrincipal instancia;
        static Usuario userActivo;

        // ================================================================================================================================= //

        public FrmPrincipal()
        {
            InitializeComponent();
            instancia = this;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogIn.ShowDialog();
            lblNombreUser.Text = userActivo.User;
        }

        public static FrmPrincipal ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new FrmPrincipal();
            }
            return instancia;
        }

        public void CargarUsuario(Usuario usuario)
        {
            userActivo = usuario;
        }


        //Metodos
        // ================================================================================================================================= //
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


        //Metodo para cambiar entre formuarios usando "paneles" como marco de muestra
        private void CambiarFormulario(Form Formulario)
        {
            //Limpia el panel si hay algun contenido
            PanelContenido.Controls.Clear();

            //Establece el formulario indicado como parametro de entrada en el panel
            Formulario.TopLevel = false;
            PanelContenido.Controls.Add(Formulario);
            Formulario.Dock = DockStyle.Fill;
            Formulario.FormBorderStyle = FormBorderStyle.None;
            Formulario.Show();
        }

        // ================================================================================================================================= //



        //Eventos
        // ================================================================================================================================= //
        //Evento por clickear sobre "Coonsultar mascotas"
        private void TSMConsutarMascotas_Click(object sender, EventArgs e)
        {
            CambiarFormulario(frmConsultarMascotas);
        }

        private void TSMSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Comentado por ahora para facilitarme las pruebas
            //if (MessageBox.Show("¿Estás seguro que desea cerrar el programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    Environment.Exit(0);
            //}

            Environment.Exit(0);
        }


        // ================================================================================================================================= //





    }
}
