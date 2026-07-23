using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.categoria
{
    public partial class FormHabilitarCategoria : System.Web.UI.Page
    {
        private CategoriaBAL bal = new CategoriaBAL();

        private CategoriaBO obj = new CategoriaBO();

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

        private void CargarCategoria()
        {
            //creamos una lista para almacenar los valores
            List<CategoriaBO> categorias = bal.findAll();
            //asignamos los valores al DataGridView
            gvHabilitarCategoria.DataSource = categorias;
            gvHabilitarCategoria.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategoria();
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
                Util.MensajePersonalizado(this, "Se habilitó la categoría");
                CargarCategoria();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar la categoría");
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se deshabilitó la categoría");
                CargarCategoria();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede deshabilitar la categoría");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCategoria.aspx");
        }

        protected void gvHabilitarCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvHabilitarCategoria.Rows[indice];
                lblCod.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}