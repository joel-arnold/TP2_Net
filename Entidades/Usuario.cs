﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : Entidad
    {
        string _NombreUsuario, _Clave, _Nombre, _Apellido, _Email;
        bool _Habilitado;

        public string NombreUsuario { get { return _NombreUsuario; } set { _NombreUsuario = value; } }
        public string Clave { get { return _Clave; } set { _Clave = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        public string Apellido { get { return _Apellido; } set { _Apellido = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public bool Habilitado { get { return _Habilitado; } set { _Habilitado = value; } }
    }
}
