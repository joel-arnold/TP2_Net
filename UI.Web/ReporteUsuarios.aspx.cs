﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReporteUsuarios1 : ABM
    {
        protected override void CargarPagina()
        {
            if ((string)Session["privilegio"] != "admin")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
        }
    }
}