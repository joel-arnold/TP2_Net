﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocenteCurso : Entidad
    {
        int _IDCurso, _IDDocente, _Cargo;

        public int IDCurso { get { return _IDCurso; } set { _IDCurso = value; } }
        public int IDDocente { get { return _IDDocente; } set { _IDDocente = value; } }
        public int Cargo { get { return _Cargo; } set { _Cargo = value; } }
    }
}
