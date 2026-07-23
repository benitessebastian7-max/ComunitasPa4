using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.autor
{
    public partial class FormHabilitarAutor : System.Web.UI.Page
    {
        private AutorBAL bal = new AutorBAL();

        private AutorBO obj = new AutorBO();

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

        private void CargarAutor()
        {
            //creamos una lista para almacenar los valores
            List<AutorBO> autores = bal.findAll();
            //asignamos los valores al DataGridView
            gvHabilitarAutor.DataSource = autores;
            gvHabilitarAutor.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAutor();
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
                Util.MensajePersonalizado(this, "Se habilitó la selección");
                CargarAutor();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar la selección");
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se habilitó la selección");
                CargarAutor();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar la selección");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormAutor.aspx");
        }

        protected void gvHabilitarAutor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvHabilitarAutor.Rows[indice];
                lblCod.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}