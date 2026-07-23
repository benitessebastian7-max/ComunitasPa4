
using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.empleado
{
    public partial class FormEmpleado : System.Web.UI.Page
    {
        private EmpleadoBAL bal = new EmpleadoBAL();
        private TipoDocumentoBAL baltp = new TipoDocumentoBAL();
        private RolBAL balrol = new RolBAL();
        private DistritoBAL baldis = new DistritoBAL();

        //creamos obj
        private EmpleadoBO obj = new EmpleadoBO();
        private TipoDocumentoBO objtp = new TipoDocumentoBO();
        private RolBO objrol = new RolBO();
        private DistritoBO objdis = new DistritoBO();

        //declaramos variables
        private int cod = 0, numhor = 0, codtp = 0, codrol = 0, coddis = 0;
        private string nom = "", apep = "", apem = "", numdoc = "", dir = "", tel = "", cor = "", usu = "", cla = "";
        private decimal sue = 0;
        private DateTime fecnac, fecing;
        private bool est = false, res = false;

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtApePat.Enabled = false;
            txtApeMat.Enabled = false;
            txtDoc.Enabled = false;
            txtFecNac.Enabled = false;
            txtFecIng.Enabled = false;
            txtDir.Enabled = false;
            txtTel.Enabled = false;
            txtCor.Enabled = false;
            txtUsu.Enabled = false;
            txtCla.Enabled = false;
            txtSue.Enabled = false;
            txtHor.Enabled = false;
            ddlTipDoc.Enabled = false;
            ddlDis.Enabled = false;
            ddlRol.Enabled = false;
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
            txtFecIng.Enabled = true;
            txtDir.Enabled = true;
            txtTel.Enabled = true;
            txtCor.Enabled = true;
            txtUsu.Enabled = true;
            txtCla.Enabled = true;
            txtSue.Enabled = true;
            txtHor.Enabled = true;
            ddlTipDoc.Enabled = true;
            ddlDis.Enabled = true;
            ddlRol.Enabled = true;
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
            txtFecIng.Text = "";
            txtDir.Text = "";
            txtTel.Text = "";
            txtCor.Text = "";
            txtUsu.Text = "";
            txtCla.Text = "";
            txtSue.Text = "";
            txtHor.Text = "";
            ddlTipDoc.SelectedIndex = 0;
            ddlDis.SelectedIndex = 0;
            ddlRol.SelectedIndex = 0;
            chkEst.Checked = false;
        }

        private void CargarEmpleado()
        {
            //creamos una lista para almacenar los valores
            List<EmpleadoBO> empleado = bal.findAllCustom();
            //asignamos los valores al GridView
            gvEmpleado.DataSource = empleado;
            gvEmpleado.DataBind();
        }

        private void cargarDropDownList()
        {
            //generamos listas con los valores de la bd
            List<TipoDocumentoBO> tipodocumento = baltp.findAllCustom();
            List<RolBO> roles = balrol.findAllCustom();
            List<DistritoBO> distritos = baldis.findAllCustom();

            //insertamos valores dentro de la lista
            TipoDocumentoBO tipdocddl = new TipoDocumentoBO()
            {
                codigo = 0,
                nombre = "Seleccione un tipo de documento",
                estado = true
            };
            tipodocumento.Insert(0, tipdocddl);

            RolBO rolddl = new RolBO()
            {
                codigo = 0,
                nombre = "Seleccione un rol",
                estado = true
            };
            roles.Insert(0, rolddl);

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

            ddlRol.DataSource = roles;
            ddlRol.DataTextField = "nombre";
            ddlRol.DataValueField = "codigo";
            ddlRol.DataBind();

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
                CargarEmpleado();
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
                else if (txtFecIng.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese la fecha de ingreso");
                    txtFecIng.Focus();
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
                else if (txtUsu.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa el usuario");
                    txtUsu.Focus();
                }
                else if (txtCla.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa la clave");
                    txtCla.Focus();
                }
                else if (txtSue.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa el sueldo");
                    txtSue.Focus();
                }
                else if (txtHor.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingresa el número de horas de trabajo");
                    txtHor.Focus();
                }
                else if (ddlDis.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona un distrito");
                    ddlDis.Focus();
                }
                else if (ddlRol.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona un rol");
                    ddlRol.Focus();
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
                    fecing = Convert.ToDateTime(txtFecIng.Text);
                    dir = txtDir.Text;
                    tel = txtTel.Text;
                    cor = txtCor.Text;
                    usu = txtUsu.Text;
                    cla = txtCla.Text;
                    sue = Convert.ToDecimal(txtSue.Text);
                    numhor = Convert.ToInt32(txtHor.Text);
                    codtp = Convert.ToInt32(ddlTipDoc.SelectedValue);
                    coddis = Convert.ToInt32(ddlDis.SelectedValue);
                    codrol = Convert.ToInt32(ddlRol.SelectedValue);
                    est = chkEst.Checked;

                    obj.nombre = nom;
                    obj.apellidopaterno = apep;
                    obj.apellidomaterno = apem;
                    obj.numerodocumento = numdoc;
                    obj.fechanacimiento = fecnac;
                    obj.fechaingreso = fecing;
                    obj.direccion = dir;
                    obj.telefono = tel;
                    obj.correo = cor;
                    obj.usuario = usu;
                    obj.clave = cla;
                    obj.sueldo = sue;
                    obj.numerohoras = numhor;
                    obj.estado = est;

                    objdis.codigo = coddis;
                    obj.distrito = objdis;

                    objrol.codigo = codrol;
                    obj.rol = objrol;

                    objtp.codigo = codtp;
                    obj.tipodocumento = objtp;

                    res = bal.add(obj);
                    if (res == true)
                    {
                        Util.MensajePersonalizado(this, "Se registró el empleado");
                        CargarEmpleado();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro el empleado");
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
            fecing = Convert.ToDateTime(txtFecIng.Text);
            dir = txtDir.Text;
            tel = txtTel.Text;
            cor = txtCor.Text;
            usu = txtUsu.Text;
            cla = txtCla.Text;
            sue = Convert.ToDecimal(txtSue.Text);
            numhor = Convert.ToInt32(txtHor.Text);
            codtp = Convert.ToInt32(ddlTipDoc.SelectedValue);
            coddis = Convert.ToInt32(ddlDis.SelectedValue);
            codrol = Convert.ToInt32(ddlRol.SelectedValue);
            est = chkEst.Checked;

            obj.nombre = nom;
            obj.apellidopaterno = apep;
            obj.apellidomaterno = apem;
            obj.numerodocumento = numdoc;
            obj.fechanacimiento = fecnac;
            obj.fechaingreso = fecing;
            obj.direccion = dir;
            obj.telefono = tel;
            obj.correo = cor;
            obj.usuario = usu;
            obj.clave = cla;
            obj.sueldo = sue;
            obj.numerohoras = numhor;
            obj.estado = est;

            objdis.codigo = coddis;
            obj.distrito = objdis;

            objrol.codigo = codrol;
            obj.rol = objrol;

            objtp.codigo = codtp;
            obj.tipodocumento = objtp;

            res = bal.update(obj, cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se actualizo el empleado");
                CargarEmpleado();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede actualizar el empleado");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino el empleado");
                CargarEmpleado();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar el empleado");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarEmpleado.aspx");
        }

        protected void gvEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvEmpleado.Rows[indice].Cells[0].Text);

                EmpleadoBO empleado = bal.findById(codigo);

                GridViewRow selectedRow = gvEmpleado.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = empleado.codigo.ToString();
                txtNom.Text = HttpUtility.HtmlDecode(empleado.nombre);
                txtApePat.Text = HttpUtility.HtmlDecode(empleado.apellidopaterno);
                txtApeMat.Text = HttpUtility.HtmlDecode(empleado.apellidomaterno);
                txtDoc.Text = empleado.numerodocumento;
                txtFecNac.Text = empleado.fechanacimiento.ToString("yyyy-MM-dd");
                txtFecIng.Text = empleado.fechaingreso.ToString("yyyy-MM-dd");
                txtDir.Text = HttpUtility.HtmlDecode(empleado.direccion);
                txtTel.Text = empleado.telefono;
                txtCor.Text = HttpUtility.HtmlDecode(empleado.correo);
                txtUsu.Text = HttpUtility.HtmlDecode(empleado.usuario);
                txtCla.Text = HttpUtility.HtmlDecode(empleado.clave);
                txtSue.Text = empleado.sueldo.ToString();
                txtHor.Text = empleado.numerohoras.ToString();
                ddlTipDoc.SelectedValue = empleado.tipodocumento.codigo.ToString();
                ddlDis.SelectedValue = empleado.distrito.codigo.ToString();
                ddlRol.SelectedValue = empleado.rol.codigo.ToString();
                chkEst.Checked = empleado.estado;
            }
        }
    }
}