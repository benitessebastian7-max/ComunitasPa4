#nullable enable
namespace pe.com.communitas.ui.Editorial;

partial class frmEditorial
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lbl1 = null!;
    private TextBox txt1 = null!;
    private CheckBox chkEstado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvEditorial = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();         lbl1 = new Label(); txt1 = new TextBox(); chkEstado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvEditorial = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvEditorial).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(250, 28); lblTitulo.Text = "Mantenimiento Simple - Editorial";
        lbl1.AutoSize = true; lbl1.Location = new Point(55, 109); lbl1.Text = "Nombre";
        txt1.Location = new Point(160, 105); txt1.Name = "txt1"; txt1.Size = new Size(220, 23);
        chkEstado.AutoSize = true; chkEstado.Location = new Point(160, 171); chkEstado.Name = "chkEstado"; chkEstado.Text = "Habilitado";
        btnNuevo.Location = new Point(55, 213); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo";
        btnRegistrar.Location = new Point(155, 213); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar";
        btnActualizar.Location = new Point(255, 213); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar";
        btnEliminar.Location = new Point(355, 213); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar";
        btnHabilitar.Location = new Point(455, 213); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar";
        dgvEditorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvEditorial.Location = new Point(55, 219); dgvEditorial.Name = "dgvEditorial"; dgvEditorial.Size = new Size(760, 250);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(875, 504); Controls.Add(dgvEditorial); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkEstado); Controls.Add(txt1); Controls.Add(lbl1); Controls.Add(lblTitulo); Name = "frmEditorial"; StartPosition = FormStartPosition.CenterScreen; Text = "frmEditorial";
        ((System.ComponentModel.ISupportInitialize)dgvEditorial).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

