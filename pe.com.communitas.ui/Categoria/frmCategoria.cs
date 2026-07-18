using System.Data;

namespace pe.com.communitas.ui.Categoria;

public partial class frmCategoria : Form
{
    private readonly DataTable _categorias = new();
    private int? _idSeleccionado;
    private int _siguienteId = 1;

    public frmCategoria()
    {
        InitializeComponent();
        _categorias.Columns.Add("Código", typeof(int));
        _categorias.Columns.Add("Nombre");
        _categorias.Columns.Add("Estado", typeof(bool));
        dgvCategorias.DataSource = _categorias;
    }

    private void btnNuevo_Click(object? sender, EventArgs e)
    {
        _idSeleccionado = null;
        txtCodigo.Clear();
        txtNombre.Clear();
        chkHabilitado.Checked = true;
        dgvCategorias.ClearSelection();
        txtNombre.Focus();
    }

    private void btnRegistrar_Click(object? sender, EventArgs e)
    {
        if (!Validar()) return;
        var fila = _categorias.NewRow();
        fila["Código"] = _siguienteId++;
        fila["Nombre"] = txtNombre.Text.Trim();
        fila["Estado"] = chkHabilitado.Checked;
        _categorias.Rows.Add(fila);
        btnNuevo_Click(sender, e);
    }

    private void btnActualizar_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado is null) { SeleccioneRegistro(); return; }
        if (!Validar()) return;
        var fila = _categorias.Rows.Find(_idSeleccionado);
        if (fila is null) return;
        fila["Nombre"] = txtNombre.Text.Trim();
        fila["Estado"] = chkHabilitado.Checked;
        btnNuevo_Click(sender, e);
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado is null) { SeleccioneRegistro(); return; }
        var fila = _categorias.Rows.Find(_idSeleccionado);
        if (fila is not null) fila["Estado"] = false;
        btnNuevo_Click(sender, e);
    }

    private void btnHabilitar_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado is null) { SeleccioneRegistro(); return; }
        var fila = _categorias.Rows.Find(_idSeleccionado);
        if (fila is not null) fila["Estado"] = true;
        chkHabilitado.Checked = true;
        dgvCategorias.Refresh();
    }

    private void dgvCategorias_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvCategorias.Rows[e.RowIndex].DataBoundItem is not DataRowView fila) return;
        _idSeleccionado = (int)fila["Código"];
        txtCodigo.Text = fila["Código"].ToString();
        txtNombre.Text = fila["Nombre"].ToString();
        chkHabilitado.Checked = (bool)fila["Estado"];
    }

    private bool Validar()
    {
        if (!string.IsNullOrWhiteSpace(txtNombre.Text)) return true;
        MessageBox.Show("Ingrese el nombre de la categoría.", "Comunitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtNombre.Focus();
        return false;
    }

    private static void SeleccioneRegistro() => MessageBox.Show("Seleccione un registro de la grilla.", "Comunitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
