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

namespace UI.Escritorio
{
    public partial class FormularioInscripcion : FormularioAplicacion
    {
        public Usuario usuarioActual;

        //CONSTRUCTOR POR DEFECTO
        public FormularioInscripcion()
        {
            InitializeComponent();
        }
        
        private AlumnoInscripciones inscripcionActual = new AlumnoInscripciones();
        private Personas personaActual = new Personas();

        public Personas PersonaActual
        {
            get
            {
                return personaActual;
            }
            set
            {
                personaActual = value;
            }
        }

        public AlumnoInscripciones InscripcionActual
        {
            get
            {
                return inscripcionActual;
            }
            set
            {
                inscripcionActual = value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //CONSTRUCTOR PARA ALTAS
        public FormularioInscripcion(ModosFormulario modo, Usuario usuario) : this()
        {
            this.usuarioActual = usuario;
            this.lblLoguinTexto.Text = usuarioActual.Nombre + " " + usuarioActual.Apellido;
            this.Modo = modo;
            this.txtID.ReadOnly = true;
            cargarMaterias();
        }

        //CONSTRUCTOR PARA MODIFICACION, BAJA Y CONSULTA
        public FormularioInscripcion(int ID, ModosFormulario modo, Usuario usuario) : this()
        {
            this.usuarioActual = usuario;
            this.lblLoguinTexto.Text = usuarioActual.Nombre + " " + usuarioActual.Apellido;
            this.Modo = modo;
            Negocio.LogicaInscripcion li = new Negocio.LogicaInscripcion();
            InscripcionActual = li.TraerUno(ID);
            MapearDeDatos();
            this.txtID.ReadOnly = true;
        }

        private void cargarMaterias()
        {
            LogicaPersona lp = new LogicaPersona();
            PersonaActual = lp.TraerUno(usuarioActual.IDPersona);
            LogicaMateria lm = new LogicaMateria();

            DataTable dtMateria = new DataTable();
            dtMateria.Columns.Add("Descripción", typeof(string));
            dtMateria.Columns.Add("ID", typeof(int));
            foreach (Materia materia in lm.TraerTodosPorIdPlan(PersonaActual.IDPlan))
            {
            dtMateria.Rows.Add(new object[] { materia.Descripcion, materia.ID });
            }
            cbbxMateria.DataSource = dtMateria;
            cbbxMateria.ValueMember = "ID";
            cbbxMateria.DisplayMember = "Descripción";
            cbbxMateria.SelectedIndex = -1;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.inscripcionActual.ID.ToString();
            Curso cu = new Curso();
            LogicaCurso lcu = new LogicaCurso();
            cu = lcu.TraerUno(this.InscripcionActual.IDCurso);
            cargarMaterias();
            this.cbbxComision.SelectedValue = cu.IDComision;
            this.cbbxMateria.SelectedValue = cu.IDMateria;
            switch (Modo)
            {
                case ModosFormulario.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModosFormulario.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModosFormulario.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModosFormulario.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModosFormulario.Alta)
            {
                AlumnoInscripciones inscripcionActual = new AlumnoInscripciones();
                inscripcionActual.Estado = Entidad.Estados.Nuevo;
            }
            else if (Modo == ModosFormulario.Modificacion)
            {
                AlumnoInscripciones inscripcionActual = new AlumnoInscripciones();
                inscripcionActual.Estado = Entidad.Estados.Modificado;
            }
            else if (Modo == ModosFormulario.Baja)
            {
                InscripcionActual.ID = int.Parse(txtID.Text);
                InscripcionActual.Estado = Entidad.Estados.Borrado;
            }
            else if (Modo == ModosFormulario.Consulta)
            {
                InscripcionActual.ID = int.Parse(txtID.Text);
                InscripcionActual.Estado = Entidad.Estados.SinModificar;
            }

            InscripcionActual.IDAlumno = this.PersonaActual.ID;
            Curso cursoActual = new Curso();
            LogicaCurso lc = new LogicaCurso();
            cursoActual = lc.TraerUnoPorMateriaYComision(Convert.ToInt32(this.cbbxMateria.SelectedValue), Convert.ToInt32(this.cbbxComision.SelectedValue));
            InscripcionActual.IDCurso = cursoActual.ID;
            inscripcionActual.Condicion = "Inscripto";
        }

        public override void GuardarCambios()
        {
            MapearADatos();

            LogicaInscripcion li = new LogicaInscripcion();
            if (btnAceptar.Text == "Guardar") { 
                if (cbbxMateria.SelectedItem == null) { MessageBox.Show("Usted no ha seleccionado ningun curso"); }
                else { 
                    bool yaInscripto = false;
                    List<AlumnoInscripciones> inscripcionesPropias = new List<AlumnoInscripciones>();
                    inscripcionesPropias = li.TraerTodosPorIdPersona(PersonaActual.ID);
                    LogicaCurso lc = new LogicaCurso();
                    foreach (AlumnoInscripciones ip in inscripcionesPropias)
                    {
                        Curso curso = new Curso();
                        curso = lc.TraerUno(ip.IDCurso);
                        if (curso.IDMateria == Convert.ToInt32(cbbxMateria.SelectedValue) && curso.IDComision == Convert.ToInt32(cbbxComision.SelectedValue))
                        {
                            yaInscripto = true;
                        }
                    }
                    if (yaInscripto)
                    {
                        MessageBox.Show("Usted ya esta Inscpripto a este curso");
                    }
                    else
                    li.Guardar(InscripcionActual);
                }
            }
            else li.Guardar(InscripcionActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();
        }

        private void cbbxMateria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LogicaComision lco = new LogicaComision();
            LogicaCurso lcu = new LogicaCurso();
            //List<Curso> cursosPorMateria = new List<Curso>();
            DataTable dtComision = new DataTable();
            dtComision.Columns.Add("Descripción", typeof(string));
            dtComision.Columns.Add("ID", typeof(int));
            //cursosPorMateria = lcu.TraerTodos(Convert.ToInt32(cbbxMateria.SelectedValue));
            foreach (Curso curso in lcu.TraerTodos(Convert.ToInt32(cbbxMateria.SelectedValue)))
            {
                Comision comision = new Comision();
                comision = lco.TraerUno(curso.IDComision);
                dtComision.Rows.Add(new object[] { comision.Descripcion, comision.ID });
            }
            cbbxComision.DataSource = dtComision;
            cbbxComision.ValueMember = "ID";
            cbbxComision.DisplayMember = "Descripción";
        }
    }
}