#nullable enable
namespace pe.com.communitas.ui.Autor;

partial class frmAutor
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lbl1 = null!;
    private TextBox txt1 = null!;
    private Label lbl2 = null!;
    private TextBox txt2 = null!;
    private Label lbl3 = null!;
    private TextBox txt3 = null!;
    private Label lbl4 = null!;
    private TextBox txt4 = null!;
    private CheckBox chkEstado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvAutor = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();         lbl1 = new Label(); txt1 = new TextBox();         lbl2 = new Label(); txt2 = new TextBox();         lbl3 = new Label(); txt3 = new TextBox();         lbl4 = new Label(); txt4 = new TextBox(); chkEstado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvAutor = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvAutor).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(250, 28); lblTitulo.Text = "Mantenimiento Cruzado - Autor";
        lbl1.AutoSize = true; lbl1.Location = new Point(55, 109); lbl1.Text = "Nombres";
        txt1.Location = new Point(160, 105); txt1.Name = "txt1"; txt1.Size = new Size(220, 23);
        lbl2.AutoSize = true; lbl2.Location = new Point(430, 109); lbl2.Text = "Apellido paterno";
        txt2.Location = new Point(555, 105); txt2.Name = "txt2"; txt2.Size = new Size(235, 23);
        lbl3.AutoSize = true; lbl3.Location = new Point(55, 155); lbl3.Text = "Apellido materno";
        txt3.Location = new Point(160, 151); txt3.Name = "txt3"; txt3.Size = new Size(220, 23);
        lbl4.AutoSize = true; lbl4.Location = new Point(430, 155); lbl4.Text = "País";
        txt4.Location = new Point(555, 151); txt4.Name = "txt4"; txt4.Size = new Size(235, 23);
        chkEstado.AutoSize = true; chkEstado.Location = new Point(160, 217); chkEstado.Name = "chkEstado"; chkEstado.Text = "Habilitado";
        btnNuevo.Location = new Point(55, 259); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo";
        btnRegistrar.Location = new Point(155, 259); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar";
        btnActualizar.Location = new Point(255, 259); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar";
        btnEliminar.Location = new Point(355, 259); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar";
        btnHabilitar.Location = new Point(455, 259); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar";
        dgvAutor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvAutor.Location = new Point(55, 265); dgvAutor.Name = "dgvAutor"; dgvAutor.Size = new Size(760, 250);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(875, 550); Controls.Add(dgvAutor); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkEstado); Controls.Add(txt1); Controls.Add(lbl1); Controls.Add(txt2); Controls.Add(lbl2); Controls.Add(txt3); Controls.Add(lbl3); Controls.Add(txt4); Controls.Add(lbl4); Controls.Add(lblTitulo); Name = "frmAutor"; StartPosition = FormStartPosition.CenterScreen; Text = "frmAutor";
        ((System.ComponentModel.ISupportInitialize)dgvAutor).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

