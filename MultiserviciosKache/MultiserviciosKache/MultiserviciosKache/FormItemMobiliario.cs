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
    public partial class FormItemMobiliario : Form
    {
        private string idMobiliario = null;
        private bool editar = false;
        private CNItem objetoitem = new CNItem();

        public FormItemMobiliario()
        {
            InitializeComponent();
        }
        private void cargaMobiliario()
        {
            CNItem obj = new CNItem();
            dgItems.DataSource = obj.mostrarMobiliario();
        }
        private void FormItemMobiliario_Load(object sender, EventArgs e)
        {
            cargaMobiliario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objetoitem.Tipo = txtTipo.Text;
            objetoitem.Cantidad = txtCantidad.Text;
            objetoitem.Alquilado = txtAlquilado.Text;

            if(editar == true)
            {
                objetoitem.Id = idMobiliario;
                try
                {
                    objetoitem.editar();
                    MessageBox.Show("El item se edito correctamente");
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La operacion fallo debido a :" + ex);
                }
            }
            else
            {
                try
                {
                    objetoitem.insertar();
                    MessageBox.Show("Los datos se inseratron correctmente");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("La insercion fallo debido a: "+ex);
                }

            }

            cargaMobiliario();
            txtAlquilado.Clear();
            txtCantidad.Clear();
            txtTipo.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dgItems.SelectedRows.Count > 0)
            {
                editar = true;
                idMobiliario = dgItems.CurrentRow.Cells["idMobiliario"].Value.ToString();
                txtTipo.Text = dgItems.CurrentRow.Cells["tipo"].Value.ToString();
                txtCantidad.Text = dgItems.CurrentRow.Cells["cantidad"].Value.ToString();
                txtAlquilado.Text = dgItems.CurrentRow.Cells["alquilado"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count > 0 )
            {
                objetoitem.Id = dgItems.CurrentRow.Cells["idMobiliario"].Value.ToString();
                objetoitem.eliminar();
                MessageBox.Show("La eliminacion se realizo correctamente");
                cargaMobiliario();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila que dese eliminar");
            }
        }
    }
}
