using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.tipodocumento
{
    public partial class FormHabilitarTipoDocumento : System.Web.UI.Page
    {
        private TipoDocumentoBAL bal = new TipoDocumentoBAL();

        private TipoDocumentoBO obj = new TipoDocumentoBO();

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

        private void CargarTipoDocumento()
        {
            //creamos una lista para almacenar los valores
            List<TipoDocumentoBO> tiposDocumento = bal.findAll();
            //asignamos los valores al DataGridView
            gvHabilitarTipoDoc.DataSource = tiposDocumento;
            gvHabilitarTipoDoc.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoDocumento();
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
                Util.MensajePersonalizado(this, "Se habilitó el tipo de documento");
                CargarTipoDocumento();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede habilitar el tipo de documento");
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se deshabilitó el tipo de documento");
                CargarTipoDocumento();
                Bloquear();
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede deshabilitar el tipo de documento");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormTipoDocumento.aspx");
        }

        protected void gvHabilitarTipoDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvHabilitarTipoDoc.Rows[indice];
                lblCod.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}