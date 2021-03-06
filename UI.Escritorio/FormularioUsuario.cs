﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;
using Data.Database;
using System.Globalization;
using System.Text.RegularExpressions;
using Util;

namespace UI.Escritorio
{
    public partial class FormularioUsuario : FormularioAplicacion
    {
        //CONSTRUCTOR POR DEFECTO
        public FormularioUsuario()
        {
            InitializeComponent();
        }

        //CONSTRUCTOR PARA ALTAS
        public FormularioUsuario(ModosFormulario modo) :this()
        {
            this.Modo = modo;
            this.txtID.ReadOnly = true;
        }

        //CONSTRUCTOR PARA MODIFICACION, BAJA Y CONSULTA
        public FormularioUsuario(int ID, ModosFormulario modo) : this()
        {
            this.Modo = modo;
            Negocio.LogicaUsuario usuario = new Negocio.LogicaUsuario();
            UsuarioActual = usuario.TraerUno(ID);
            MapearDeDatos();
            this.txtID.ReadOnly = true;
            if(this.Modo == ModosFormulario.Baja)
            {
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConfirmarClave.ReadOnly = true;
                this.txtID.ReadOnly = true;
                this.txtCorreoE.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.chkHabilitado.Enabled = true;
                this.txtPrivilegio.ReadOnly = true;
            }
        }

        private Usuario usuarioActual = new Usuario();

        public Usuario UsuarioActual
        {
            get
            {
                return usuarioActual;
            }
            set
            {
                usuarioActual = value;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {         

        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //SOBRE-ESCRITURA DE LOS METODOS DE LA CLASE PADRE
        public override void MapearADatos()
        {
            if (Modo == ModosFormulario.Alta)
            {
                Usuario usuarioActual = new Usuario();
                UsuarioActual.Estado = Entidad.Estados.Nuevo;
            }
            else if (Modo == ModosFormulario.Modificacion)
            {
                UsuarioActual.ID = int.Parse(txtID.Text);
                UsuarioActual.Estado = Entidad.Estados.Modificado;
            }
            else if (Modo == ModosFormulario.Baja)
            {
                UsuarioActual.ID = int.Parse(txtID.Text);
                UsuarioActual.Estado = Entidad.Estados.Borrado;
            }
            else if (Modo == ModosFormulario.Consulta)
            {
                UsuarioActual.ID = int.Parse(txtID.Text);
                UsuarioActual.Estado = Entidad.Estados.SinModificar;
            }
            UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            UsuarioActual.Nombre = this.txtNombre.Text;
            UsuarioActual.Apellido = this.txtApellido.Text;
            UsuarioActual.Email = this.txtCorreoE.Text;
            UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            UsuarioActual.Clave = this.txtClave.Text;
            UsuarioActual.Privilegio = this.txtPrivilegio.Text;
            UsuarioActual.IDPersona = Convert.ToInt32(cbbxPersona.SelectedValue);
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtCorreoE.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.txtPrivilegio.Text = this.usuarioActual.Privilegio;
            this.cbbxPersona.SelectedValue = this.usuarioActual.IDPersona;

            //Acá configuro el texto del botón aceptar según sea el modo con el que se llamó al formulario
            switch (Modo)
            {
                case  ModosFormulario.Alta: btnAceptar.Text = "Guardar";
                    break;

                case ModosFormulario.Modificacion: btnAceptar.Text = "Guardar";
                    break;

                case ModosFormulario.Baja: btnAceptar.Text = "Eliminar";
                break;

                case ModosFormulario.Consulta: btnAceptar.Text = "Aceptar";
                break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            LogicaUsuario logicaUsuarioActual = new LogicaUsuario();
            logicaUsuarioActual.Guardar(UsuarioActual);
        }

        public override bool Validar()
        {
            bool valida = false;
            string mensaje = "";

            if (txtApellido.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 || txtCorreoE.Text.Trim().Length == 0 || txtPrivilegio.Text.Trim().Length == 0
                || txtUsuario.Text.Trim().Length == 0 || txtClave.Text.Trim().Length == 0 || txtConfirmarClave.Text.Trim().Length == 0)
                mensaje += "Debe completar todos los campos" + "\n";
            if (!Validacion.esClaveValida(txtClave.Text))
                mensaje += "La clave debe contener al menos 8 caracteres" + "\n";
            if (!Validacion.clavesCoinciden(txtClave.Text, txtConfirmarClave.Text))
                mensaje += "Las claves no coinciden" + "\n";
            if (!Validacion.esMailValido(txtCorreoE.Text))
                mensaje += "El correo electrónico ingresado no es válido";
            if (!Validacion.esPrivilegioValido(txtPrivilegio.Text))
                mensaje += "El campo Privilegio solo puede contener ''admin'' o 'invitado'' ";

            if (!String.IsNullOrEmpty(mensaje))
            {
                this.Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valida = true;
            }

            return valida;
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public override void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
          if(this.Modo != ModosFormulario.Baja)
            {
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
          else
            {
                GuardarCambios();
                this.Close();
            }
                    
        }

        private void FormularioUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.personas' Puede moverla o quitarla según sea necesario.
            this.personasTableAdapter.Fill(this.tp2_netDataSet.personas);

        }
    }
}