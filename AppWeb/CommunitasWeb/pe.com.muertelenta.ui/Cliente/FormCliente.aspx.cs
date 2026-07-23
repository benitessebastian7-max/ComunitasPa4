using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.cliente
{
    public partial class FormCliente : System.Web.UI.Page
    {
        private ClienteBAL bal = new ClienteBAL();
        private TipoDocumentoBAL baltp = new TipoDocumentoBAL();
        private DistritoBAL baldis = new DistritoBAL();

        //creamos obj
        private ClienteBO obj = new ClienteBO();
        private TipoDocumentoBO objtp = new TipoDocumentoBO();
        private DistritoBO objdis = new DistritoBO();

        //declaramos variables
        private int cod = 0, codtp = 0, coddis = 0;
        private string nom = "", apep = "", apem = "", numdoc = "", dir = "", tel = "", cor = "";
        private DateTime fecnac;
        private bool est = false, res = false;

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtApePat.Enabled = false;
            txtApeMat.Enabled = false;
            txtDoc.Enabled = false;
            txtFecNac.Enabled = false;
            txtDir.Enabled = false;
            txtTel.Enabled = false;
            txtCor.Enabled = false;
            ddlTipDoc.Enabled = false;
            ddlDis.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtNom.Enabled = true;
            txtApePat.Enabled = true;
            txtApeMat.Enabled = true;
            txtDoc.Enabled = true;
            txtFecNac.Enabled = true;
            txtDir.Enabled = true;
            txtTel.Enabled = true;
            txtCor.Enabled = true;
            ddlTipDoc.Enabled = true;
            ddlDis.Enabled = true;
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
            txtApePat.Text = "";
            txtApeMat.Text = "";
            txtDoc.Text = "";
            txtFecNac.Text = "";
            txtDir.Text = "";
            txtTel.Text = "";
            txtCor.Text = "";
            ddlTipDoc.SelectedIndex = 0;
            ddlDis.SelectedIndex = 0;
            chkEst.Checked = false;
        }

        private void CargarCliente()
        {
            //creamos una lista para almacenar los valores
            List<ClienteBO> empleado = bal.findAllCustom();
            //asignamos los valores al GridView
            gvCliente.DataSource = empleado;
            gvCliente.DataBind();
        }

        private void cargarDropDownList()
        {
            //generamos listas con los valores de la bd
            List<TipoDocumentoBO> tipodocumento = baltp.findAllCustom();
            List<DistritoBO> distritos = baldis.findAllCustom();

            //insertamos valores dentro de la lista
            TipoDocumentoBO tipdocddl = new TipoDocumentoBO()
            {
                codigo = 0,
                nombre = "Seleccione un tipo de documento",
                estado = true
            };
            tipodocumento.Insert(0, tipdocddl);

            DistritoBO distritoddl = new DistritoBO()
            {
                codigo = 0,
                nombre = "Seleccione un distrito",
                estado = true
            };
            distritos.Insert(0, distritoddl);

            //cargar el ddl
            ddlTipDoc.DataSource = tipodocumento;
            ddlTipDoc.DataTextField = "nombre";
            ddlTipDoc.DataValueField = "codigo";
            ddlTipDoc.DataBind();

            ddlDis.DataSource = distritos;
            ddlDis.DataTextField = "nombre";
            ddlDis.DataValueField = "codigo";
            ddlDis.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bloquear();
                SoloLectura();
                CargarCliente();
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
                else if (txtApePat.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el apellido paterno");
                    txtApePat.Focus();
                }
                else if (txtApeMat.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el apellido materno");
                    txtApeMat.Focus();
                }
                else if (txtDoc.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el número de documento");
                    txtDoc.Focus();
                }
                else if (txtFecNac.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese la fecha de nacimiento");
                    txtFecNac.Focus();
                }
                else if (txtDir.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa una dirección");
                    txtDir.Focus();
                }
                else if (txtTel.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa un teléfono");
                    txtTel.Focus();
                }
                else if (txtCor.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa un correo");
                    txtCor.Focus();
                }
                else if (ddlDis.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona un distrito");
                    ddlDis.Focus();
                }
                else if (ddlTipDoc.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona un tipo de documento");
                    ddlTipDoc.Focus();
                }
                else
                {
                    nom = txtNom.Text;
                    apep = txtApePat.Text;
                    apem = txtApeMat.Text;
                    numdoc = txtDoc.Text;
                    fecnac = Convert.ToDateTime(txtFecNac.Text);
                    dir = txtDir.Text;
                    tel = txtTel.Text;
                    cor = txtCor.Text;
                    codtp = Convert.ToInt32(ddlTipDoc.SelectedValue);
                    coddis = Convert.ToInt32(ddlDis.SelectedValue);
                    est = chkEst.Checked;

                    obj.nombre = nom;
                    obj.apellidopaterno = apep;
                    obj.apellidomaterno = apem;
                    obj.numerodocumento = numdoc;
                    obj.fechanacimiento = fecnac;
                    obj.direccion = dir;
                    obj.telefono = tel;
                    obj.correo = cor;
                    obj.estado = est;

                    objdis.codigo = coddis;
                    obj.distrito = objdis;

                    objtp.codigo = codtp;
                    obj.tipodocumento = objtp;

                    res = bal.add(obj);
                    if (res == true)
                    {
                        Util.MensajePersonalizado(this, "Se registró el cliente");
                        CargarCliente();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro el cliente");
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
            apep = txtApePat.Text;
            apem = txtApeMat.Text;
            numdoc = txtDoc.Text;
            fecnac = Convert.ToDateTime(txtFecNac.Text);
            dir = txtDir.Text;
            tel = txtTel.Text;
            cor = txtCor.Text;
            codtp = Convert.ToInt32(ddlTipDoc.SelectedValue);
            coddis = Convert.ToInt32(ddlDis.SelectedValue);
            est = chkEst.Checked;

            obj.nombre = nom;
            obj.apellidopaterno = apep;
            obj.apellidomaterno = apem;
            obj.numerodocumento = numdoc;
            obj.fechanacimiento = fecnac;
            obj.direccion = dir;
            obj.telefono = tel;
            obj.correo = cor;
            obj.estado = est;

            objdis.codigo = coddis;
            obj.distrito = objdis;

            objtp.codigo = codtp;
            obj.tipodocumento = objtp;

            res = bal.update(obj, cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se actualizo el cliente");
                CargarCliente();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede actualizar el cliente");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino el cliente");
                CargarCliente();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar el cliente");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarCliente.aspx");
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvCliente.Rows[indice].Cells[0].Text);

                ClienteBO cliente = bal.findById(codigo);

                GridViewRow selectedRow = gvCliente.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = cliente.codigo.ToString();
                txtNom.Text = HttpUtility.HtmlDecode(cliente.nombre);
                txtApePat.Text = HttpUtility.HtmlDecode(cliente.apellidopaterno);
                txtApeMat.Text = HttpUtility.HtmlDecode(cliente.apellidomaterno);
                txtDoc.Text = cliente.numerodocumento;
                txtFecNac.Text = cliente.fechanacimiento.ToString("yyyy-MM-dd");
                txtDir.Text = HttpUtility.HtmlDecode(cliente.direccion);
                txtTel.Text = cliente.telefono;
                txtCor.Text = HttpUtility.HtmlDecode(cliente.correo);
                ddlTipDoc.SelectedValue = cliente.tipodocumento.codigo.ToString();
                ddlDis.SelectedValue = cliente.distrito.codigo.ToString();
                chkEst.Checked = cliente.estado;
            }
        }
    }
}