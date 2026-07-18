#nullable enable
namespace pe.com.communitas.ui.Editorial;

partial class frmHabilitarEditorial
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvRegistros = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label(); btnHabilitar = new Button(); dgvRegistros = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(185, 28); lblTitulo.Text = "Habilitar Editorial";
        btnHabilitar.Location = new Point(54, 86); btnHabilitar.Name = "btnHabilitar"; btnHabilitar.Size = new Size(90, 25); btnHabilitar.Text = "Habilitar";
        dgvRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvRegistros.Location = new Point(54, 135); dgvRegistros.Name = "dgvRegistros"; dgvRegistros.Size = new Size(610, 300);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(715, 470); Controls.Add(dgvRegistros); Controls.Add(btnHabilitar); Controls.Add(lblTitulo); Name = "frmHabilitarEditorial"; StartPosition = FormStartPosition.CenterScreen; Text = "frmHabilitarEditorial";
        ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

