﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_15._08__CarpinteriaApp_.Presentacion;

namespace Clase_15._08__CarpinteriaApp_
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        //Evento al clickear sobre "nuevo" en el menu "Presupuesto"
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoPresupuesto nuevoPresupuesto = new NuevoPresupuesto();
            nuevoPresupuesto.ShowDialog();
        }
    }
}