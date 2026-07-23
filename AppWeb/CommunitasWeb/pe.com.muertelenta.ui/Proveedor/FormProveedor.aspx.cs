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

namespace pe.com.communitas.ui.proveedor
{
    public partial class FormProveedor : System.Web.UI.Page
    {
        private ProveedorBAL bal = new ProveedorBAL();

        //creamos obj tipoplatoBO
        private ProveedorBO obj = new ProveedorBO();

        //declaramos variables
        private int cod = 0;
        private string nom = "", ruc = "", dir = "", tel = "", cor = "";
        private bool est = false, res = false;

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtRazSoc.Enabled = false;
            txtRuc.Enabled = false;
            txtDir.Enabled = false;
            txtTel.Enabled = false;
            txtCor.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtRazSoc.Enabled = true;
            txtRuc.Enabled = true;
            txtDir.Enabled = true;
            txtTel.Enabled = true;
            txtCor.Enabled = true;
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
            txtRazSoc.Text = "";
            txtRuc.Text = "";
            txtDir.Text = "";
            txtTel.Text = "";
            txtCor.Text = "";
            chkEst.Checked = false;
        }

        private void CargarProveedor()
        {
            //creamos una lista para almacenar los valores
            List<ProveedorBO> proveedor = bal.findAllCustom();
            //asignamos los valores al GridView
            gvProveedor.DataSource = proveedor;
            gvProveedor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bloquear();
                SoloLectura();
                CargarProveedor();
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
                if (txtRazSoc.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese la razón social del proveedor");
                    txtRazSoc.Focus();
                }
                else if (txtRuc.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el ruc");
                    txtRuc.Focus();
                }
                else if (txtDir.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese la dirección");
                    txtDir.Focus();
                }
                else if (txtTel.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el teléfono");
                    txtTel.Focus();
                }
                else if (txtCor.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el correo");
                    txtCor.Focus();
                }
                else
                {
                    nom = txtRazSoc.Text;
                    ruc = txtRuc.Text;
                    dir = txtDir.Text;
                    tel = txtTel.Text;
                    cor = txtCor.Text;
                    est = chkEst.Checked;

                    obj.razonsocial = nom;
                    obj.ruc = ruc;
                    obj.direccion = dir;
                    obj.telefono = tel;
                    obj.correo = cor;
                    obj.estado = est;
                    res = bal.add(obj);
                    if (res == true)
                    {
                        Util.MensajePersonalizado(this, "Se registró el proveedor");
                        CargarProveedor();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro el proveedor");
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
            nom = txtRazSoc.Text;
            ruc = txtRuc.Text;
            dir = txtDir.Text;
            tel = txtTel.Text;
            cor = txtCor.Text;
            est = chkEst.Checked;

            obj.razonsocial = nom;
            obj.ruc = ruc;
            obj.direccion = dir;
            obj.telefono = tel;
            obj.correo = cor;
            obj.estado = est;
            res = bal.update(obj, cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se actualizó el proveedor");
                CargarProveedor();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se actualizó el proveedor");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino el proveedor");
                CargarProveedor();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar el proveedor");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarProveedor.aspx");
        }

        protected void gvProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvProveedor.Rows[indice].Cells[0].Text);

                ProveedorBO proveedor = bal.findById(codigo);

                GridViewRow selectedRow = gvProveedor.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = proveedor.codigo.ToString();
                txtRazSoc.Text = HttpUtility.HtmlDecode(proveedor.razonsocial);
                txtRuc.Text = proveedor.ruc;
                txtDir.Text = proveedor.direccion;
                txtTel.Text = proveedor.telefono;
                txtCor.Text = proveedor.correo;
                chkEst.Checked = proveedor.estado;
            }
        }
    }
}