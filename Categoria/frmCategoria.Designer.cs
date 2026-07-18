#nullable enable
namespace pe.com.communitas.ui.Categoria;

partial class frmCategoria
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblCodigo = null!;
    private Label lblNombre = null!;
    private TextBox txtCodigo = null!;
    private TextBox txtNombre = null!;
    private CheckBox chkHabilitado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvCategorias = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label(); lblCodigo = new Label(); lblNombre = new Label(); txtCodigo = new TextBox(); txtNombre = new TextBox(); chkHabilitado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvCategorias = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(205, 28); lblTitulo.Text = "Mantenimiento Simple - Categoría";
        lblCodigo.AutoSize = true; lblCodigo.Location = new Point(48, 103); lblCodigo.Text = "Código";
        txtCodigo.Location = new Point(116, 95); txtCodigo.Name = "txtCodigo"; txtCodigo.ReadOnly = true; txtCodigo.Size = new Size(319, 23);
        lblNombre.AutoSize = true; lblNombre.Location = new Point(48, 149); lblNombre.Text = "Nombre";
        txtNombre.Location = new Point(116, 141); txtNombre.Name = "txtNombre"; txtNombre.Size = new Size(319, 23);
        chkHabilitado.AutoSize = true; chkHabilitado.Location = new Point(116, 202); chkHabilitado.Name = "chkHabilitado"; chkHabilitado.Text = "Habilitado";
        btnNuevo.Location = new Point(48, 240); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo"; btnNuevo.Click += btnNuevo_Click;
        btnRegistrar.Location = new Point(165, 240); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar"; btnRegistrar.Click += btnRegistrar_Click;
        btnActualizar.Location = new Point(290, 240); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar"; btnActualizar.Click += btnActualizar_Click;
        btnEliminar.Location = new Point(406, 240); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar"; btnEliminar.Click += btnEliminar_Click;
        btnHabilitar.Location = new Point(534, 240); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar"; btnHabilitar.Click += btnHabilitar_Click;
        dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvCategorias.Location = new Point(48, 290); dgvCategorias.Name = "dgvCategorias"; dgvCategorias.Size = new Size(628, 330); dgvCategorias.CellClick += dgvCategorias_CellClick;
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(716, 640); Controls.Add(dgvCategorias); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkHabilitado); Controls.Add(txtNombre); Controls.Add(lblNombre); Controls.Add(txtCodigo); Controls.Add(lblCodigo); Controls.Add(lblTitulo); Name = "frmCategoria"; StartPosition = FormStartPosition.CenterScreen; Text = "frmCategoria";
        ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit(); ResumeLayout(false); PerformLayout();
    }
}
