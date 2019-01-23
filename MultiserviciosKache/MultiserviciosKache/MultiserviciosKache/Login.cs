using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;

namespace MultiserviciosKache
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CNEmpleado objEmpleado = new CNEmpleado();
            SqlDataReader loguear;
            if (txtUsuario.Text != "")
                try
                {
                    objEmpleado.Ci = txtUsuario.Text;
                }catch(Exception ex)
                {
                    objEmpleado.Ci = "";
                    MessageBox.Show(ex.ToString());
                }
                
            else objEmpleado.Ci = "";
            objEmpleado.Contrasenia = txtContrasenia.Text;            
            loguear = objEmpleado.iniciaSesion();
            if (loguear.Read() == true)
            {
                this.Hide();
                FormPrincipal objFP = new FormPrincipal();                
                objFP.Show();
            }
            else
                MessageBox.Show(" Datos incorrectos");

        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {   
                txtContrasenia.UseSystemPasswordChar = true;
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if(txtContrasenia.Text == "contraseña")
            {
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }
    }
}
