using pe.com.muertelenta.bal;
using pe.com.muertelenta.bo;
using pe.com.muertelenta.ui.Orden;
using pe.com.muertelenta.ui.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pe.com.muertelenta.ui
{
    public partial class FormIngreso : Form
    {
        private EmpleadoBAL empleadoBAL = new EmpleadoBAL();
        string usu = "", cla = "";
        List<EmpleadoBO> Empleados = new List<EmpleadoBO>();
        public FormIngreso()
        {
            InitializeComponent();
            progressBar1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Util.MensajePersonalizado("Ingrese su usuario", "Ingreso", 0, 48);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                Util.MensajePersonalizado("Ingrese su contraseña", "Ingreso", 0, 48);
                textBox2.Focus();
            }
            else
            {
                usu = textBox1.Text;
                cla = textBox2.Text;
                Empleados = empleadoBAL.login(usu, cla);
                if (Empleados.Count == 1)
                {
                    if (Empleados[0].estado == true)
                    {
                        progressBar1.Value = 0;
                        progressBar1.Visible = true;
                        timer1.Enabled = true;
                    }
                    else
                    {
                        Util.MensajePersonalizado("Usuario o contraseña incorrectos", "Ingreso", 0, 16);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                else
                {
                    Util.MensajePersonalizado("Usuario o contraseña incorrectos", "Ingreso", 0, 16);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           DialogResult respuesta = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                progressBar1.Refresh();
                await Task.Delay(600);
                Util.MensajePersonalizado("Bienvenido " + Empleados[0].nombre, "Ingreso", 0, 48);
                EmpleadoBO empleadoLogin = Empleados[0];
                FormMenuPrincipal formulario = new FormMenuPrincipal(empleadoLogin);
                Hide();
                formulario.Show();
            }       
        }
    }
}
