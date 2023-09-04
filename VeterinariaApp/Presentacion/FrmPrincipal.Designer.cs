namespace VeterinariaApp
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMCientes = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMConsultarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMNuevoCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMMascotas = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMConsutarMascotas = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMNuevaMascota = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMAtenciones = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMConsultarAtenciones = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMNuevaAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelContenido = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMArchivo,
            this.TSMCientes,
            this.TSMMascotas,
            this.TSMAtenciones});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMArchivo
            // 
            this.TSMArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMSalir});
            this.TSMArchivo.Name = "TSMArchivo";
            this.TSMArchivo.Size = new System.Drawing.Size(60, 20);
            this.TSMArchivo.Text = "Archivo";
            // 
            // TSMSalir
            // 
            this.TSMSalir.Name = "TSMSalir";
            this.TSMSalir.Size = new System.Drawing.Size(180, 22);
            this.TSMSalir.Text = "Salir";
            // 
            // TSMCientes
            // 
            this.TSMCientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMConsultarClientes,
            this.TSMNuevoCliente});
            this.TSMCientes.Name = "TSMCientes";
            this.TSMCientes.Size = new System.Drawing.Size(61, 20);
            this.TSMCientes.Text = "Clientes";
            // 
            // TSMConsultarClientes
            // 
            this.TSMConsultarClientes.Name = "TSMConsultarClientes";
            this.TSMConsultarClientes.Size = new System.Drawing.Size(180, 22);
            this.TSMConsultarClientes.Text = "Consultar";
            // 
            // TSMNuevoCliente
            // 
            this.TSMNuevoCliente.Name = "TSMNuevoCliente";
            this.TSMNuevoCliente.Size = new System.Drawing.Size(180, 22);
            this.TSMNuevoCliente.Text = "Nuevo";
            // 
            // TSMMascotas
            // 
            this.TSMMascotas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMConsutarMascotas,
            this.TSMNuevaMascota});
            this.TSMMascotas.Name = "TSMMascotas";
            this.TSMMascotas.Size = new System.Drawing.Size(69, 20);
            this.TSMMascotas.Text = "Mascotas";
            // 
            // TSMConsutarMascotas
            // 
            this.TSMConsutarMascotas.Name = "TSMConsutarMascotas";
            this.TSMConsutarMascotas.Size = new System.Drawing.Size(180, 22);
            this.TSMConsutarMascotas.Text = "Consultar";
            this.TSMConsutarMascotas.Click += new System.EventHandler(this.TSMConsutarMascotas_Click);
            // 
            // TSMNuevaMascota
            // 
            this.TSMNuevaMascota.Name = "TSMNuevaMascota";
            this.TSMNuevaMascota.Size = new System.Drawing.Size(180, 22);
            this.TSMNuevaMascota.Text = "Nueva";
            // 
            // TSMAtenciones
            // 
            this.TSMAtenciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMConsultarAtenciones,
            this.TSMNuevaAtencion});
            this.TSMAtenciones.Name = "TSMAtenciones";
            this.TSMAtenciones.Size = new System.Drawing.Size(78, 20);
            this.TSMAtenciones.Text = "Atenciones";
            // 
            // TSMConsultarAtenciones
            // 
            this.TSMConsultarAtenciones.Name = "TSMConsultarAtenciones";
            this.TSMConsultarAtenciones.Size = new System.Drawing.Size(180, 22);
            this.TSMConsultarAtenciones.Text = "Consutar";
            // 
            // TSMNuevaAtencion
            // 
            this.TSMNuevaAtencion.Name = "TSMNuevaAtencion";
            this.TSMNuevaAtencion.Size = new System.Drawing.Size(180, 22);
            this.TSMNuevaAtencion.Text = "Nueva";
            // 
            // PanelContenido
            // 
            this.PanelContenido.Location = new System.Drawing.Point(0, 27);
            this.PanelContenido.Name = "PanelContenido";
            this.PanelContenido.Size = new System.Drawing.Size(800, 420);
            this.PanelContenido.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelContenido);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Carpinteria App (Gabriel de Maussion)";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMArchivo;
        private System.Windows.Forms.ToolStripMenuItem TSMSalir;
        private System.Windows.Forms.ToolStripMenuItem TSMCientes;
        private System.Windows.Forms.ToolStripMenuItem TSMConsultarClientes;
        private System.Windows.Forms.ToolStripMenuItem TSMNuevoCliente;
        private System.Windows.Forms.ToolStripMenuItem TSMMascotas;
        private System.Windows.Forms.ToolStripMenuItem TSMConsutarMascotas;
        private System.Windows.Forms.ToolStripMenuItem TSMAtenciones;
        private System.Windows.Forms.ToolStripMenuItem TSMConsultarAtenciones;
        private System.Windows.Forms.ToolStripMenuItem TSMNuevaAtencion;
        private System.Windows.Forms.ToolStripMenuItem TSMNuevaMascota;
        private System.Windows.Forms.Panel PanelContenido;
    }
}

