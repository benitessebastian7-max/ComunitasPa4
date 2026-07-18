#nullable enable
namespace pe.com.communitas.ui.LibroAutor;

partial class frmLibroAutor
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lbl1 = null!;
    private TextBox txt1 = null!;
    private Label lbl2 = null!;
    private TextBox txt2 = null!;
    private CheckBox chkEstado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvLibroAutor = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();         lbl1 = new Label(); txt1 = new TextBox();         lbl2 = new Label(); txt2 = new TextBox(); chkEstado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvLibroAutor = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvLibroAutor).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(250, 28); lblTitulo.Text = "Mantenimiento Cruzado - Libro - Autor";
        lbl1.AutoSize = true; lbl1.Location = new Point(55, 109); lbl1.Text = "Autor";
        txt1.Location = new Point(160, 105); txt1.Name = "txt1"; txt1.Size = new Size(220, 23);
        lbl2.AutoSize = true; lbl2.Location = new Point(430, 109); lbl2.Text = "Producto";
        txt2.Location = new Point(555, 105); txt2.Name = "txt2"; txt2.Size = new Size(235, 23);
        chkEstado.AutoSize = true; chkEstado.Location = new Point(160, 171); chkEstado.Name = "chkEstado"; chkEstado.Text = "Habilitado";
        btnNuevo.Location = new Point(55, 213); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo";
        btnRegistrar.Location = new Point(155, 213); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar";
        btnActualizar.Location = new Point(255, 213); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar";
        btnEliminar.Location = new Point(355, 213); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar";
        btnHabilitar.Location = new Point(455, 213); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar";
        dgvLibroAutor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvLibroAutor.Location = new Point(55, 219); dgvLibroAutor.Name = "dgvLibroAutor"; dgvLibroAutor.Size = new Size(760, 250);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(875, 504); Controls.Add(dgvLibroAutor); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkEstado); Controls.Add(txt1); Controls.Add(lbl1); Controls.Add(txt2); Controls.Add(lbl2); Controls.Add(lblTitulo); Name = "frmLibroAutor"; StartPosition = FormStartPosition.CenterScreen; Text = "frmLibroAutor";
        ((System.ComponentModel.ISupportInitialize)dgvLibroAutor).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

