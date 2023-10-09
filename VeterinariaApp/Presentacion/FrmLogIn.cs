using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinariaApp.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeterinariaApp.Presentacion
{
    public partial class FrmLogIn : Form
    {
        FrmPrincipal principal;
        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            principal = FrmPrincipal.ObtenerInstancia();
        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            txtUser.Margin = new Padding(10, 3, 3, 3);
            if (txtUser.Text == "")
            {
                lblUser.Text = "Usuario";
            }
            else
            {
                lblUser.Text = "";
            }

            if (txtPass.Text == "")
            {
                lblPass.Text = "Contraseña";
            }
            else
            {
                lblPass.Text = "";
            }
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                MessageBox.Show("Debe introducir un usuario valido");
                lblUser.Focus();
                return;
            }
            if(txtPass.Text == "")
            {
                MessageBox.Show("Debe introducir una contraseña valida");
                lblPass.Focus();
                return;
            }

            Usuario usuario = new Usuario();

            usuario.User = txtUser.Text;
            usuario.Pass = txtPass.Text;

            principal.CargarUsuario(usuario);
            this.Close();

        }
    }
}
