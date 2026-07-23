using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.rol
{
    public partial class FormHabilitarRol : System.Web.UI.Page
    {
        private RolBAL bal = new RolBAL();

        private RolBO obj = new RolBO();

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

        private void CargarRol()
        {
            //creamos una lista para almacenar los valores
            List<RolBO> roles = bal.findAll();
            //asignamos los valores al DataGridView
            gvHabilitarRol.DataSource = roles;
            gvHabilitarRol.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRol();
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
                Util.MensajePersonalizado(this, "Se habilitó el rol");
                CargarRol();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar el rol");
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se deshabilitó el rol");
                CargarRol();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede deshabilitar el rol");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormRol.aspx");
        }

        protected void gvHabilitarRol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvHabilitarRol.Rows[indice];
                lblCod.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}