using pe.com.communitas.bal;
using pe.com.communitas.bo;
using pe.com.communitas.dal;
using pe.com.communitas.ui.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.communitas.ui.producto
{
    public partial class FormProducto : System.Web.UI.Page
    {
        private ProductoBAL bal = new ProductoBAL();
        private ProveedorBAL balprov = new ProveedorBAL();
        private CategoriaBAL balcat = new CategoriaBAL();
        private EditorialBAL baledit = new EditorialBAL();

        //creamos obj
        private ProductoBO obj = new ProductoBO();
        private ProveedorBO objprov = new ProveedorBO();
        private CategoriaBO objcat = new CategoriaBO();
        private EditorialBO objedit = new EditorialBO();

        //declaramos variables
        private int cod = 0, codprov = 0, codcat = 0, codedi = 0;
        private string isbn = "", tit = "", desc = "";
        private decimal precom = 0, preven = 0;
        private DateTime fecpub;
        private bool est = false, res = false;

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtIsbn.Enabled = false;
            txtTit.Enabled = false;
            txtDesc.Enabled = false;
            txtPreCom.Enabled = false;
            txtPreVen.Enabled = false;
            txtFecPub.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlEditorial.Enabled = false;
            ddlProveedor.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtIsbn.Enabled = true;
            txtTit.Enabled = true;
            txtDesc.Enabled = true;
            txtPreCom.Enabled = true;
            txtPreVen.Enabled = true;
            txtFecPub.Enabled = true;
            ddlCategoria.Enabled = true;
            ddlEditorial.Enabled = true;
            ddlProveedor.Enabled = true;
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
            txtIsbn.Text = "";
            txtTit.Text = "";
            txtDesc.Text = "";
            txtPreCom.Text = "";
            txtPreVen.Text = "";
            txtFecPub.Text = "";
            ddlCategoria.SelectedIndex = 0;
            ddlEditorial.SelectedIndex = 0;
            ddlProveedor.SelectedIndex = 0;
            chkEst.Enabled = true;
        }

        private void CargarProducto()
        {
            //creamos una lista para almacenar los valores
            List<ProductoBO> producto = bal.findAllCustom();
            //asignamos los valores al GridView
            gvProducto.DataSource = producto;
            gvProducto.DataBind();
        }

        private void cargarDropDownList()
        {
            //generamos listas con los valores de la bd
            List<ProveedorBO> proveedores = balprov.findAllCustom();
            List<CategoriaBO> categorias = balcat.findAllCustom();
            List<EditorialBO> editoriales = baledit.findAllCustom();

            //insertamos valores dentro de la lista
            ProveedorBO proveedorddl = new ProveedorBO()
            {
                codigo = 0,
                razonsocial = "Seleccione un proveedor",
                estado = true
            };
            proveedores.Insert(0, proveedorddl);

            CategoriaBO categoriaddl = new CategoriaBO()
            {
                codigo = 0,
                nombre = "Seleccione una categoría",
                estado = true
            };
            categorias.Insert(0, categoriaddl);

            EditorialBO editorialddl = new EditorialBO()
            {
                codigo = 0,
                nombre = "Seleccione una editorial",
                estado = true
            };
            editoriales.Insert(0, editorialddl);

            //cargar el ddl
            ddlProveedor.DataSource = proveedores;
            ddlProveedor.DataTextField = "razonsocial";
            ddlProveedor.DataValueField = "codigo";
            ddlProveedor.DataBind();

            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "nombre";
            ddlCategoria.DataValueField = "codigo";
            ddlCategoria.DataBind();

            ddlEditorial.DataSource = editoriales;
            ddlEditorial.DataTextField = "nombre";
            ddlEditorial.DataValueField = "codigo";
            ddlEditorial.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bloquear();
                SoloLectura();
                CargarProducto();
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
                if (txtIsbn.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el isbn");
                    txtIsbn.Focus();
                }
                else if (txtTit.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el título");
                    txtTit.Focus();
                }
                else if (txtDesc.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese la descripción");
                    txtDesc.Focus();
                }
                else if (txtPreCom.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el precio de compra");
                    txtPreCom.Focus();
                }
                else if (txtPreVen.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese el precio de venta");
                    txtPreVen.Focus();
                }
                else if (txtFecPub.Text == "")
                {
                    Util.MensajePersonalizado(this, "Ingrese la fecha de publicación");
                    txtFecPub.Focus();
                }
                else if (ddlCategoria.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona una categoría");
                    ddlCategoria.Focus();
                }
                else if (ddlEditorial.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona una editorial");
                    ddlEditorial.Focus();
                }
                else if (ddlProveedor.SelectedIndex == 0)
                {
                    Util.MensajePersonalizado(this, "Selecciona un proveedor");
                    ddlProveedor.Focus();
                }
                else
                {
                    isbn = txtIsbn.Text;
                    tit = txtTit.Text;
                    desc = txtDesc.Text;
                    precom = Convert.ToDecimal(txtPreCom.Text);
                    preven = Convert.ToDecimal(txtPreVen.Text);
                    fecpub = Convert.ToDateTime(txtFecPub.Text);
                    codcat = Convert.ToInt32(ddlCategoria.SelectedValue);
                    codedi = Convert.ToInt32(ddlEditorial.SelectedValue);
                    codprov = Convert.ToInt32(ddlProveedor.SelectedValue);
                    est = chkEst.Checked;


                    obj.isbn = isbn;
                    obj.titulo = tit;
                    obj.descripcion = desc;
                    obj.preciocompra = precom;
                    obj.precioventa = preven;
                    obj.fechapublicacion = fecpub;
                    obj.estado = est;

                    objcat.codigo = codcat;
                    obj.categoria = objcat;

                    objedit.codigo = codedi;
                    obj.editorial = objedit;

                    objprov.codigo = codprov;
                    obj.proveedor = objprov;

                    res = bal.add(obj);
                    if (res == true)
                    {
                        Util.MensajePersonalizado(this, "Se registró el producto");
                        CargarProducto();
                        Limpiar();
                        Bloquear();
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado(this, "No se registro el producto");
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
            isbn = txtIsbn.Text;
            tit = txtTit.Text;
            desc = txtDesc.Text;
            precom = Convert.ToDecimal(txtPreCom.Text);
            preven = Convert.ToDecimal(txtPreVen.Text);
            fecpub = Convert.ToDateTime(txtFecPub.Text);
            codcat = Convert.ToInt32(ddlCategoria.SelectedValue);
            codedi = Convert.ToInt32(ddlEditorial.SelectedValue);
            codprov = Convert.ToInt32(ddlProveedor.SelectedValue);
            est = chkEst.Checked;


            obj.isbn = isbn;
            obj.titulo = tit;
            obj.descripcion = desc;
            obj.preciocompra = precom;
            obj.precioventa = preven;
            obj.fechapublicacion = fecpub;
            obj.estado = est;

            objcat.codigo = codcat;
            obj.categoria = objcat;

            objedit.codigo = codedi;
            obj.editorial = objedit;

            objprov.codigo = codprov;
            obj.proveedor = objprov;

            res = bal.update(obj, cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se actualizo el producto");
                CargarProducto();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede actualizar el producto");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(txtCod.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                Util.MensajePersonalizado(this, "Se elimino el producto");
                CargarProducto();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                Util.MensajePersonalizado(this, "No se puede eliminar el producto");
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormHabilitarProducto.aspx");

        }

        protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;

                int indice = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gvProducto.Rows[indice].Cells[0].Text);

                ProductoBO producto = bal.findById(codigo);

                GridViewRow selectedRow = gvProducto.Rows[indice];

                //asignamos valores a los controles
                txtCod.Text = producto.codigo.ToString();
                txtIsbn.Text = HttpUtility.HtmlDecode(producto.isbn);
                txtTit.Text = HttpUtility.HtmlDecode(producto.titulo);
                txtDesc.Text = HttpUtility.HtmlDecode(producto.descripcion);
                txtPreCom.Text = producto.preciocompra.ToString();
                txtPreVen.Text = producto.precioventa.ToString();
                txtFecPub.Text = producto.fechapublicacion.ToString("yyyy-MM-dd");
                ddlCategoria.SelectedValue = producto.categoria.codigo.ToString();
                ddlEditorial.SelectedValue = producto.editorial.codigo.ToString();
                ddlProveedor.SelectedValue = producto.proveedor.codigo.ToString();
                chkEst.Checked = producto.estado;
            }
        }
    }
}