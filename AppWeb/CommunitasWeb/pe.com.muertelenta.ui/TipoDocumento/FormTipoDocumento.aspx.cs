using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.tipodocumento
{
    public partial class FormTipoDocumento : System.Web.UI.Page
    {
        private TipoDocumentoBAL bal = new TipoDocumentoBAL();

        //creamos obj tipoplatoBO
        private TipoDocumentoBO obj = new TipoDocumentoBO();

        //declaramos variables
        private int cod = 0;
        private string nom = "";
        private bool est = false, res = false;

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtNom.Enabled = true;
            chkEst.Enabled = true;
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }

        private void Limpiar()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            chkEst.Checked = false;
        }

        private void CargarTipoDocumento()
        {
            //creamos una lista para almacenar los valores
            List<TipoDocumentoBO> tiposDocumento = bal.findAllCustom();
            //asignamos los valores al GridView
            gvTipoDoc.DataSource = tiposDocumento;
            gvTipoDoc.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bloquear();
                SoloLectura();
                CargarTipoDocumento();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Desbloquear();
            Limpiar();
            btnNuevo.Enabled = false;
            txtCod.Text = bal.setCode().ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNom.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el nombre");
                    txtNom.Focus();
                }
                else
                {
                    nom = txtNom.Text;
                    est = chkEst.Checked;
                    obj.nombre = nom;
                    obj.estado = est;
                    res = bal.add(obj);
                    if (res == true)
                    {
                        Util.MensajePersonalizado(this, "Se registró el tipo de documento");
                        CargarTipoDocumento();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro el tipo de documento");
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            nom = txtNom.Text;
            est = chkEst.Checked;
            obj.codigo = cod;
            obj.nombre = nom;
            obj.estado = est;
            res = bal.update(obj, cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se actualizo el tipo de documento");
                CargarTipoDocumento();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede actualizar el tipo de documento");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino el tipo de documento");
                CargarTipoDocumento();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar el tipo de documento");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarTipoDocumento.aspx");
        }

        protected void gvTipoDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvTipoDoc.Rows[indice].Cells[0].Text);

                TipoDocumentoBO tipoDocumento = bal.findById(codigo);

                GridViewRow selectedRow = gvTipoDoc.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = tipoDocumento.codigo.ToString();
                txtNom.Text = HttpUtility.HtmlDecode(tipoDocumento.nombre);
                chkEst.Checked = tipoDocumento.estado;
            }
        }
    }
}