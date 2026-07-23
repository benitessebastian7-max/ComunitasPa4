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

namespace pe.com.communitas.ui.editorial
{
    public partial class FormEditorial : System.Web.UI.Page
    {
        private EditorialBAL bal = new EditorialBAL();

        //creamos obj tipoplatoBO
        private EditorialBO obj = new EditorialBO();

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

        private void CargarEditorial()
        {
            //creamos una lista para almacenar los valores
            List<EditorialBO> editorial = bal.findAllCustom();
            //asignamos los valores al GridView
            gvEditorial.DataSource = editorial;
            gvEditorial.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bloquear();
                SoloLectura();
                CargarEditorial();
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
                        Util.MensajePersonalizado(this, "Se registró la editorial");
                        CargarEditorial();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro la editorial");
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
                Util.MensajePersonalizado(this, "Se actualizo la editorial");
                CargarEditorial();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede actualizar la editorial");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino la editorial");
                CargarEditorial();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar la editorial");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarEditorial.aspx");
        }

        protected void gvEditorial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvEditorial.Rows[indice].Cells[0].Text);

                EditorialBO editorial = bal.findById(codigo);

                GridViewRow selectedRow = gvEditorial.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = editorial.codigo.ToString();
                txtNom.Text = HttpUtility.HtmlDecode(editorial.nombre);
                chkEst.Checked = editorial.estado;
            }
        }
    }
}