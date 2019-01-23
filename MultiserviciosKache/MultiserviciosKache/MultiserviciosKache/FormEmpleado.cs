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
    public partial class FormEmpleado : Form
    {
        private CNEmpleado objetoCN = new CNEmpleado();
        private string idEmpleado = null;
        private Boolean editar = false;
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void cargarEmpleados()
        {
            CNEmpleado objeto = new CNEmpleado();
            dgEmpleados.DataSource = objeto.mostrarEmpleados();
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {

            cargarEmpleados();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            objetoCN.Nombre = txtNombre.Text;
            objetoCN.Apellido = txtApellido.Text;
            objetoCN.Puesto = txtPuesto.Text;

            if (editar == false)
            {
                try
                {
                    objetoCN.insertaEmpleado();
                    MessageBox.Show("La insercion se realizo exitosamente:");                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo debido a: " + ex);
                }
            }
            else
            {
                objetoCN.Ci = idEmpleado;
                try
                {
                    objetoCN.editarEmpleado();
                    MessageBox.Show("La edicion se realizo exitosamente:");                    
                    editar = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Fallo debido a: " + ex);
                }
            }
            cargarEmpleados();
            txtNombre.Clear();
            txtApellido.Clear();
            txtPuesto.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dgEmpleados.SelectedRows.Count > 0)
            {
                editar = true;  
                txtNombre.Text = dgEmpleados.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dgEmpleados.CurrentRow.Cells["apellido"].Value.ToString();
                txtPuesto.Text = dgEmpleados.CurrentRow.Cells["puesto"].Value.ToString();
                idEmpleado = dgEmpleados.CurrentRow.Cells["idEmpleado"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar la fila a editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgEmpleados.SelectedRows.Count > 0)
            {                
                objetoCN.Ci = dgEmpleados.CurrentRow.Cells["idEmpleado"].Value.ToString();
                objetoCN.eliminarEmpleado();
                MessageBox.Show("Se elimino el registro exitosamente");
                cargarEmpleados();
            }
            else
            {
                MessageBox.Show("Debe seleccionar la fila para eliminar");
            }
        }
    }
}
