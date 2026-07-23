
using pe.com.communitas.bal;
using pe.com.communitas.bo;
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
        private EmpleadoBAL bal = new EmpleadoBAL();

        private EmpleadoBO obj = new EmpleadoBO();

        private int cod = 0, indice = -1;
        private bool res = false;

        private void Bloquear()
        {
            btnHabilitar.Enabled = false;
            btnDeshabilitar.Enabled = false;
        }

        private void Desbloquear()
        {
            btnHabilitar.Enabled = true;
            btnDeshabilitar.Enabled = true;
        }

        private void CargarEmpleado()
        {
            //creamos una lista para almacenar los valores
            List<EmpleadoBO> empleados = bal.findAll();
            //asignamos los valores al DataGridView
            gvHabilitarEmpleado.DataSource = empleados;
            gvHabilitarEmpleado.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleado();
                Bloquear();
                lblCod.Visible = false;
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.enable(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se habilitó el empleado");
                CargarEmpleado();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar el empleado");
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se deshabilitó el empleado");
                CargarEmpleado();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede deshabilitar el empleado");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormEmpleado.aspx");
        }

        protected void gvHabilitarEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvHabilitarEmpleado.Rows[indice];
                lblCod.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}