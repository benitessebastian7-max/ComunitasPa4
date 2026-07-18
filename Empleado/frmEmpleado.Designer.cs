#nullable enable
namespace pe.com.communitas.ui.Empleado;

partial class frmEmpleado
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
    private Label lbl11 = null!;
    private TextBox txt11 = null!;
    private Label lbl12 = null!;
    private TextBox txt12 = null!;
    private Label lbl13 = null!;
    private TextBox txt13 = null!;
    private Label lbl14 = null!;
    private TextBox txt14 = null!;
    private Label lbl15 = null!;
    private TextBox txt15 = null!;
    private Label lbl16 = null!;
    private TextBox txt16 = null!;
    private CheckBox chkEstado = null!;
    private Button btnNuevo = null!;
    private Button btnRegistrar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnHabilitar = null!;
    private DataGridView dgvEmpleado = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();         lbl1 = new Label(); txt1 = new TextBox();         lbl2 = new Label(); txt2 = new TextBox();         lbl3 = new Label(); txt3 = new TextBox();         lbl4 = new Label(); txt4 = new TextBox();         lbl5 = new Label(); txt5 = new TextBox();         lbl6 = new Label(); txt6 = new TextBox();         lbl7 = new Label(); txt7 = new TextBox();         lbl8 = new Label(); txt8 = new TextBox();         lbl9 = new Label(); txt9 = new TextBox();         lbl10 = new Label(); txt10 = new TextBox();         lbl11 = new Label(); txt11 = new TextBox();         lbl12 = new Label(); txt12 = new TextBox();         lbl13 = new Label(); txt13 = new TextBox();         lbl14 = new Label(); txt14 = new TextBox();         lbl15 = new Label(); txt15 = new TextBox();         lbl16 = new Label(); txt16 = new TextBox(); chkEstado = new CheckBox(); btnNuevo = new Button(); btnRegistrar = new Button(); btnActualizar = new Button(); btnEliminar = new Button(); btnHabilitar = new Button(); dgvEmpleado = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvEmpleado).BeginInit(); SuspendLayout();
        lblTitulo.AutoSize = true; lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold); lblTitulo.Location = new Point(250, 28); lblTitulo.Text = "Mantenimiento Cruzado - Empleado";
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
        lbl9.AutoSize = true; lbl9.Location = new Point(55, 293); lbl9.Text = "Fecha de ingreso";
        txt9.Location = new Point(160, 289); txt9.Name = "txt9"; txt9.Size = new Size(220, 23);
        lbl10.AutoSize = true; lbl10.Location = new Point(430, 293); lbl10.Text = "Usuario";
        txt10.Location = new Point(555, 289); txt10.Name = "txt10"; txt10.Size = new Size(235, 23);
        lbl11.AutoSize = true; lbl11.Location = new Point(55, 339); lbl11.Text = "Clave";
        txt11.Location = new Point(160, 335); txt11.Name = "txt11"; txt11.Size = new Size(220, 23);
        lbl12.AutoSize = true; lbl12.Location = new Point(430, 339); lbl12.Text = "Sueldo";
        txt12.Location = new Point(555, 335); txt12.Name = "txt12"; txt12.Size = new Size(235, 23);
        lbl13.AutoSize = true; lbl13.Location = new Point(55, 385); lbl13.Text = "Horas";
        txt13.Location = new Point(160, 381); txt13.Name = "txt13"; txt13.Size = new Size(220, 23);
        lbl14.AutoSize = true; lbl14.Location = new Point(430, 385); lbl14.Text = "Tipo de documento";
        txt14.Location = new Point(555, 381); txt14.Name = "txt14"; txt14.Size = new Size(235, 23);
        lbl15.AutoSize = true; lbl15.Location = new Point(55, 431); lbl15.Text = "Rol";
        txt15.Location = new Point(160, 427); txt15.Name = "txt15"; txt15.Size = new Size(220, 23);
        lbl16.AutoSize = true; lbl16.Location = new Point(430, 431); lbl16.Text = "Distrito";
        txt16.Location = new Point(555, 427); txt16.Name = "txt16"; txt16.Size = new Size(235, 23);
        chkEstado.AutoSize = true; chkEstado.Location = new Point(160, 493); chkEstado.Name = "chkEstado"; chkEstado.Text = "Habilitado";
        btnNuevo.Location = new Point(55, 535); btnNuevo.Size = new Size(75, 23); btnNuevo.Text = "Nuevo";
        btnRegistrar.Location = new Point(155, 535); btnRegistrar.Size = new Size(75, 23); btnRegistrar.Text = "Registrar";
        btnActualizar.Location = new Point(255, 535); btnActualizar.Size = new Size(75, 23); btnActualizar.Text = "Actualizar";
        btnEliminar.Location = new Point(355, 535); btnEliminar.Size = new Size(75, 23); btnEliminar.Text = "Eliminar";
        btnHabilitar.Location = new Point(455, 535); btnHabilitar.Size = new Size(75, 23); btnHabilitar.Text = "Habilitar";
        dgvEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; dgvEmpleado.Location = new Point(55, 541); dgvEmpleado.Name = "dgvEmpleado"; dgvEmpleado.Size = new Size(760, 250);
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(242, 242, 242); ClientSize = new Size(875, 826); Controls.Add(dgvEmpleado); Controls.Add(btnHabilitar); Controls.Add(btnEliminar); Controls.Add(btnActualizar); Controls.Add(btnRegistrar); Controls.Add(btnNuevo); Controls.Add(chkEstado); Controls.Add(txt1); Controls.Add(lbl1); Controls.Add(txt2); Controls.Add(lbl2); Controls.Add(txt3); Controls.Add(lbl3); Controls.Add(txt4); Controls.Add(lbl4); Controls.Add(txt5); Controls.Add(lbl5); Controls.Add(txt6); Controls.Add(lbl6); Controls.Add(txt7); Controls.Add(lbl7); Controls.Add(txt8); Controls.Add(lbl8); Controls.Add(txt9); Controls.Add(lbl9); Controls.Add(txt10); Controls.Add(lbl10); Controls.Add(txt11); Controls.Add(lbl11); Controls.Add(txt12); Controls.Add(lbl12); Controls.Add(txt13); Controls.Add(lbl13); Controls.Add(txt14); Controls.Add(lbl14); Controls.Add(txt15); Controls.Add(lbl15); Controls.Add(txt16); Controls.Add(lbl16); Controls.Add(lblTitulo); Name = "frmEmpleado"; StartPosition = FormStartPosition.CenterScreen; Text = "frmEmpleado";
        ((System.ComponentModel.ISupportInitialize)dgvEmpleado).EndInit(); ResumeLayout(false); PerformLayout();
    }
}

