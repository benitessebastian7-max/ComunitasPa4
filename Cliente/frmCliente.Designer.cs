#nullable enable
namespace pe.com.communitas.ui.Cliente;

partial class frmCliente
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
    private Label lbl6 = null!;
    private TextBox txt6 = null!;
    private Label lbl7 = null!;
    private TextBox txt7 = null!;
    private Label lbl8 = null!;
    private TextBox txt8 = null!;
    private Label lbl9 = null!;
    private TextBox txt9 = null!;
    private Label lbl10 = null!;
    private TextBox txt10 = null!;
    private CheckBox chkEstado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvCliente = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();         lbl1 = new Label(); txt1 = new TextBox();         lbl2 = new Label(); txt2 = new TextBox();         lbl3 = new Label(); txt3 = new TextBox();         lbl4 = new Label(); txt4 = new TextBox();         lbl5 = new Label(); txt5 = new TextBox();         lbl6 = new Label(); txt6 = new TextBox();         lbl7 = new Label(); txt7 = new TextBox();         lbl8 = new Label(); txt8 = new TextBox();         lbl9 = new Label(); txt9 = new TextBox();         lbl10 = new Label(); txt10 = new TextBox(); chkEstado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvCliente = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(250, 28); lblTitulo.Text = "Mantenimiento Cruzado - Cliente";
        lbl1.AutoSize = true; lbl1.Location = new Point(55, 109); lbl1.Text = "Nombres";
        txt1.Location = new Point(160, 105); txt1.Name = "txt1"; txt1.Size = new Size(220, 23);
        lbl2.AutoSize = true; lbl2.Location = new Point(430, 109); lbl2.Text = "Apellido paterno";
        txt2.Location = new Point(555, 105); txt2.Name = "txt2"; txt2.Size = new Size(235, 23);
        lbl3.AutoSize = true; lbl3.Location = new Point(55, 155); lbl3.Text = "Apellido materno";
        txt3.Location = new Point(160, 151); txt3.Name = "txt3"; txt3.Size = new Size(220, 23);
        lbl4.AutoSize = true; lbl4.Location = new Point(430, 155); lbl4.Text = "Documento";
        txt4.Location = new Point(555, 151); txt4.Name = "txt4"; txt4.Size = new Size(235, 23);
        lbl5.AutoSize = true; lbl5.Location = new Point(55, 201); lbl5.Text = "Fecha de nacimiento";
        txt5.Location = new Point(160, 197); txt5.Name = "txt5"; txt5.Size = new Size(220, 23);
        lbl6.AutoSize = true; lbl6.Location = new Point(430, 201); lbl6.Text = "Dirección";
        txt6.Location = new Point(555, 197); txt6.Name = "txt6"; txt6.Size = new Size(235, 23);
        lbl7.AutoSize = true; lbl7.Location = new Point(55, 247); lbl7.Text = "Teléfono";
        txt7.Location = new Point(160, 243); txt7.Name = "txt7"; txt7.Size = new Size(220, 23);
        lbl8.AutoSize = true; lbl8.Location = new Point(430, 247); lbl8.Text = "Correo";
        txt8.Location = new Point(555, 243); txt8.Name = "txt8"; txt8.Size = new Size(235, 23);
        lbl9.AutoSize = true; lbl9.Location = new Point(55, 293); lbl9.Text = "Tipo de documento";
        txt9.Location = new Point(160, 289); txt9.Name = "txt9"; txt9.Size = new Size(220, 23);
        lbl10.AutoSize = true; lbl10.Location = new Point(430, 293); lbl10.Text = "Distrito";
        txt10.Location = new Point(555, 289); txt10.Name = "txt10"; txt10.Size = new Size(235, 23);
        chkEstado.AutoSize = true; chkEstado.Location = new Point(160, 355); chkEstado.Name = "chkEstado"; chkEstado.Text = "Habilitado";
        btnNuevo.Location = new Point(55, 397); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo";
        btnRegistrar.Location = new Point(155, 397); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar";
        btnActualizar.Location = new Point(255, 397); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar";
        btnEliminar.Location = new Point(355, 397); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar";
        btnHabilitar.Location = new Point(455, 397); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar";
        dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvCliente.Location = new Point(55, 403); dgvCliente.Name = "dgvCliente"; dgvCliente.Size = new Size(760, 250);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(875, 688); Controls.Add(dgvCliente); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkEstado); Controls.Add(txt1); Controls.Add(lbl1); Controls.Add(txt2); Controls.Add(lbl2); Controls.Add(txt3); Controls.Add(lbl3); Controls.Add(txt4); Controls.Add(lbl4); Controls.Add(txt5); Controls.Add(lbl5); Controls.Add(txt6); Controls.Add(lbl6); Controls.Add(txt7); Controls.Add(lbl7); Controls.Add(txt8); Controls.Add(lbl8); Controls.Add(txt9); Controls.Add(lbl9); Controls.Add(txt10); Controls.Add(lbl10); Controls.Add(lblTitulo); Name = "frmCliente"; StartPosition = FormStartPosition.CenterScreen; Text = "frmCliente";
        ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

