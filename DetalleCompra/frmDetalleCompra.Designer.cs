#nullable enable
namespace pe.com.communitas.ui.DetalleCompra;

partial class frmDetalleCompra
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
    private Label lbl5 = null!;
    private TextBox txt5 = null!;
    private CheckBox chkEstado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvDetalleCompra = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();         lbl1 = new Label(); txt1 = new TextBox();         lbl2 = new Label(); txt2 = new TextBox();         lbl3 = new Label(); txt3 = new TextBox();         lbl4 = new Label(); txt4 = new TextBox();         lbl5 = new Label(); txt5 = new TextBox(); chkEstado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvDetalleCompra = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(250, 28); lblTitulo.Text = "Mantenimiento Cruzado - Detalle de compra";
        lbl1.AutoSize = true; lbl1.Location = new Point(55, 109); lbl1.Text = "Compra";
        txt1.Location = new Point(160, 105); txt1.Name = "txt1"; txt1.Size = new Size(220, 23);
        lbl2.AutoSize = true; lbl2.Location = new Point(430, 109); lbl2.Text = "Producto";
        txt2.Location = new Point(555, 105); txt2.Name = "txt2"; txt2.Size = new Size(235, 23);
        lbl3.AutoSize = true; lbl3.Location = new Point(55, 155); lbl3.Text = "Cantidad";
        txt3.Location = new Point(160, 151); txt3.Name = "txt3"; txt3.Size = new Size(220, 23);
        lbl4.AutoSize = true; lbl4.Location = new Point(430, 155); lbl4.Text = "Precio unitario";
        txt4.Location = new Point(555, 151); txt4.Name = "txt4"; txt4.Size = new Size(235, 23);
        lbl5.AutoSize = true; lbl5.Location = new Point(55, 201); lbl5.Text = "Subtotal";
        txt5.Location = new Point(160, 197); txt5.Name = "txt5"; txt5.Size = new Size(220, 23);
        chkEstado.AutoSize = true; chkEstado.Location = new Point(160, 263); chkEstado.Name = "chkEstado"; chkEstado.Text = "Habilitado";
        btnNuevo.Location = new Point(55, 305); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo";
        btnRegistrar.Location = new Point(155, 305); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar";
        btnActualizar.Location = new Point(255, 305); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar";
        btnEliminar.Location = new Point(355, 305); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar";
        btnHabilitar.Location = new Point(455, 305); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar";
        dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvDetalleCompra.Location = new Point(55, 311); dgvDetalleCompra.Name = "dgvDetalleCompra"; dgvDetalleCompra.Size = new Size(760, 250);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(875, 596); Controls.Add(dgvDetalleCompra); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkEstado); Controls.Add(txt1); Controls.Add(lbl1); Controls.Add(txt2); Controls.Add(lbl2); Controls.Add(txt3); Controls.Add(lbl3); Controls.Add(txt4); Controls.Add(lbl4); Controls.Add(txt5); Controls.Add(lbl5); Controls.Add(lblTitulo); Name = "frmDetalleCompra"; StartPosition = FormStartPosition.CenterScreen; Text = "frmDetalleCompra";
        ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

