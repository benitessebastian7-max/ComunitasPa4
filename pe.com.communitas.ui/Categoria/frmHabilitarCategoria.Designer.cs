#nullable enable
namespace pe.com.communitas.ui.Categoria;

partial class frmHabilitarCategoria
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvCategorias = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label(); btnHabilitar = new Button(); dgvCategorias = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(185, 28); lblTitulo.Text = "Habilitar categorías";
        btnHabilitar.Location = new Point(54, 86); btnHabilitar.Name = "btnHabilitar"; btnHabilitar.Size = new Size(90, 25); btnHabilitar.Text = "Habilitar";
        dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvCategorias.Location = new Point(54, 135); dgvCategorias.Name = "dgvCategorias"; dgvCategorias.Size = new Size(610, 300);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(715, 470); Controls.Add(dgvCategorias); Controls.Add(btnHabilitar); Controls.Add(lblTitulo); Name = "frmHabilitarCategoria"; StartPosition = FormStartPosition.CenterScreen; Text = "frmHabilitarCategoria";
        ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit(); ResumeLayout(false); PerformLayout();
    }
}
