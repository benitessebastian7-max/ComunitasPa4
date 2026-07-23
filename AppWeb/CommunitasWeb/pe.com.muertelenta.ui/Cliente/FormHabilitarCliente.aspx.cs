using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.cliente
{
    public partial class FormHabilitarCliente : System.Web.UI.Page
    {
        private ClienteBAL bal = new ClienteBAL();

        private ClienteBO obj = new ClienteBO();

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

        private void CargarCliente()
        {
            //creamos una lista para almacenar los valores
            List<ClienteBO> clientes = bal.findAll();
            //asignamos los valores al DataGridView
            gvHabilitarCliente.DataSource = clientes;
            gvHabilitarCliente.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCliente();
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
                Util.MensajePersonalizado(this, "Se habilitó el cliente");
                CargarCliente();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar el cliente");
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se deshabilitó el cliente");
                CargarCliente();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede deshabilitar el cliente");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCliente.aspx");
        }

        protected void gvHabilitarCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvHabilitarCliente.Rows[indice];
                lblCod.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}