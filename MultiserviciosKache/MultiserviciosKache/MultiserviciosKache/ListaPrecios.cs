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
namespace MultiserviciosKache
{
    public partial class ListaPrecios : Form
    {
        private CNPrecio objetoPrecio = new CNPrecio();
        public ListaPrecios()
        {
            InitializeComponent();
        }
        public void cargarPrecios()
        {
            
        }

        private void ListaPrecios_Load(object sender, EventArgs e)
        {
            dgPrecios.DataSource = objetoPrecio.mostrarPrecios();
        }
    }
}
