
using pe.com.communitas.ui.util; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.empleado 
{
    public partial class FormEmpleado : System.Web.UI.Page
    {

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarEmpleado.aspx");
        }

        protected void gvEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}