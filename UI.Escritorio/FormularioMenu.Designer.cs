﻿namespace UI.Escritorio
{
    partial class FormularioMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuAcciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuABMCUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuABMCEspecialidad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuABMCPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAcciones});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(1270, 24);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuAcciones
            // 
            this.mnuAcciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuABMCUsuarios,
            this.mnuABMCEspecialidad,
            this.mnuABMCPlanes,
            this.mnuInscripcion,
            this.mnuNotas,
            this.mnuReportes,
            this.mnuSalir});
            this.mnuAcciones.Name = "mnuAcciones";
            this.mnuAcciones.Size = new System.Drawing.Size(67, 20);
            this.mnuAcciones.Text = "Acciones";
            // 
            // mnuABMCUsuarios
            // 
            this.mnuABMCUsuarios.Name = "mnuABMCUsuarios";
            this.mnuABMCUsuarios.Size = new System.Drawing.Size(176, 22);
            this.mnuABMCUsuarios.Text = "ABMC Usuarios";
            this.mnuABMCUsuarios.Click += new System.EventHandler(this.mnuABMCUsuarios_Click);
            // 
            // mnuABMCEspecialidad
            // 
            this.mnuABMCEspecialidad.Name = "mnuABMCEspecialidad";
            this.mnuABMCEspecialidad.Size = new System.Drawing.Size(176, 22);
            this.mnuABMCEspecialidad.Text = "ABMC Especialidad";
            this.mnuABMCEspecialidad.Click += new System.EventHandler(this.mnuABMCEspecialidad_Click);
            // 
            // mnuABMCPlanes
            // 
            this.mnuABMCPlanes.Name = "mnuABMCPlanes";
            this.mnuABMCPlanes.Size = new System.Drawing.Size(176, 22);
            this.mnuABMCPlanes.Text = "ABMC Planes";
            this.mnuABMCPlanes.Click += new System.EventHandler(this.mnuABMCPlanes_Click);
            // 
            // mnuInscripcion
            // 
            this.mnuInscripcion.Name = "mnuInscripcion";
            this.mnuInscripcion.Size = new System.Drawing.Size(176, 22);
            this.mnuInscripcion.Text = "Inscripcion";
            this.mnuInscripcion.Click += new System.EventHandler(this.mnuInscripcion_Click);
            // 
            // mnuNotas
            // 
            this.mnuNotas.Name = "mnuNotas";
            this.mnuNotas.Size = new System.Drawing.Size(176, 22);
            this.mnuNotas.Text = "Cargar Notas";
            this.mnuNotas.Click += new System.EventHandler(this.cargarNotasToolStripMenuItem_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personasToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(176, 22);
            this.mnuReportes.Text = "Reportes";
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.personasToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(176, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // FormularioMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Escritorio.Properties.Resources.academia;
            this.ClientSize = new System.Drawing.Size(1270, 461);
            this.Controls.Add(this.mnsPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Name = "FormularioMenu";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormularioMenu_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuAcciones;
        private System.Windows.Forms.ToolStripMenuItem mnuABMCUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuABMCEspecialidad;
        private System.Windows.Forms.ToolStripMenuItem mnuABMCPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripcion;
        private System.Windows.Forms.ToolStripMenuItem mnuNotas;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}