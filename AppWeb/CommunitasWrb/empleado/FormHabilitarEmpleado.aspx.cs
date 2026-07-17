
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.empleado
{
    public partial class FormHabilitarEmpleado : System.Web.UI.Page
    {
        protected void btnHabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormEmpleado.aspx");
        }

        protected void gvHabilitarEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}
