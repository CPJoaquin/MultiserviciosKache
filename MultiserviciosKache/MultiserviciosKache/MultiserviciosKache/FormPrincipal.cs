using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MultiserviciosKache
{
    public partial class FormPrincipal : Form
    {
        private string dato;

        public string Dato
        {
            get
            {
                return dato;
            }

            set
            {
                dato = value;
            }
        }

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(Cabecera.Height == 50)
            {
                Cabecera.Height = 150;
                Menu.Visible = true;
            }else{
                Cabecera.Height = 50;
                Menu.Visible = false;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void oculta()
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
            lbl9.Visible = false;
            lbl10.Visible = false;
            lbl11.Visible = false;
            lbl12.Visible = false;
            lbl13.Visible = false;
            lbl14.Visible = false;
            lbl15.Visible = false;
            lbl16.Visible = false;
            lbl17.Visible = false;
            pbFiesta.Visible = false;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void abrirFormSecundario(object formSec)
        {
            oculta();
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
            Form fs = formSec as Form;
            fs.TopLevel = false;
            fs.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(fs);
            this.Contenedor.Tag = fs;
            fs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Clear();
            Cabecera.Height = 50;
            Menu.Visible = false;
            abrirFormSecundario(new FormEmpleado());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            oculta();
            Cabecera.Height = 50;
            Menu.Visible = false;
            this.Contenedor.Controls.Clear();
            abrirFormSecundario(new FormContrato());          
            
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Clear();
            oculta();
            Cabecera.Height = 50;
            Menu.Visible = false;
            abrirFormSecundario(new ListaPrecios());
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Clear();
            oculta();
            Cabecera.Height = 50;
            Menu.Visible = false;
            abrirFormSecundario(new FormItemMobiliario());
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            lblFecha.Text = fecha.ToString("dd-MM-yyyy");            
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
