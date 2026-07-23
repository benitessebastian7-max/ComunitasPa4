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

namespace pe.com.communitas.ui.autor
{
    public partial class FormAutor : System.Web.UI.Page
    {
        private AutorBAL bal = new AutorBAL();
        private PaisBAL pbal = new PaisBAL();

        //creamos obj tipoplatoBO
        private AutorBO obj = new AutorBO();
        private PaisBO pobj = new PaisBO();

        //declaramos variables
        private int cod = 0, codpais = 0;
        private string nom = "", apep = "", apem = "";
        private bool est = false, res = false;

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtApep.Enabled = false;
            txtApem.Enabled = false;
            ddlPais.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtNom.Enabled = true;
            txtApep.Enabled = true;
            txtApem.Enabled = true;
            ddlPais.Enabled = true;
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
            txtApem.Text = "";
            txtApep.Text = "";
            ddlPais.SelectedIndex = 0;
            chkEst.Checked = false;
        }

        private void CargarAutor()
        {
            //creamos una lista para almacenar los valores
            List<AutorBO> autor = bal.findAllCustom();
            //asignamos los valores al GridView
            gvAutor.DataSource = autor;
            gvAutor.DataBind();
        }

        private void cargarDropDownList()
        {
            //generamos listas con los valores de la bd
            List<PaisBO> pais = pbal.findAllCustom();

            //insertamos valores dentro de la lista
            PaisBO paisddl = new PaisBO()
            {
                codigo = 0,
                nombre = "Seleccione un pais",
                estado = true
            };
            pais.Insert(0, paisddl);

            //cargar el ddl
            ddlPais.DataSource = pais;
            ddlPais.DataTextField = "nombre";
            ddlPais.DataValueField = "codigo";
            ddlPais.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bloquear();
                SoloLectura();
                CargarAutor();
                cargarDropDownList();
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Desbloquear();
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
                    apep = txtApep.Text;
                    apem = txtApem.Text;
                    codpais = Convert.ToInt32(ddlPais.SelectedValue);
                    est = chkEst.Checked;

                    obj.nombre = nom;
                    obj.apellidopaterno = apep;
                    obj.apellidomaterno = apem;
                    obj.estado = est;

                    pobj.codigo = codpais;
                    obj.pais = pobj;

                    res = bal.add(obj);
                    if (res == true)
                    {
                        Util.MensajePersonalizado(this, "Se registró el autor");
                        CargarAutor();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro el autor");
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
            apep = txtApep.Text;
            apem = txtApem.Text;
            codpais = Convert.ToInt32(ddlPais.SelectedValue);
            est = chkEst.Checked;

            obj.nombre = nom;
            obj.apellidopaterno = apep;
            obj.apellidomaterno = apem;
            obj.estado = est;

            pobj.codigo = codpais;
            obj.pais = pobj;

            res = bal.update(obj, cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se actualizo el autor");
                CargarAutor();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede actualizar el autor");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino el autor");
                CargarAutor();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar el autor");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarAutor.aspx");
        }

        protected void gvAutor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvAutor.Rows[indice].Cells[0].Text);

                AutorBO autor = bal.findById(codigo);

                GridViewRow selectedRow = gvAutor.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = autor.codigo.ToString();
                txtNom.Text = HttpUtility.HtmlDecode(autor.nombre);
                txtApep.Text = HttpUtility.HtmlDecode(autor.apellidopaterno);
                txtApem.Text = HttpUtility.HtmlDecode(autor.apellidomaterno);
                ddlPais.SelectedValue = autor.pais.codigo.ToString();
                chkEst.Checked = autor.estado;
            }
        }
    }
}