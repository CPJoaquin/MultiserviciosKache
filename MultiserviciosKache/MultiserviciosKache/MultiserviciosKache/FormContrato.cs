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
    public partial class FormContrato : Form
    {
        private bool editar = false;
        private string idContrato="";
        CNContrato objetoContrato = new CNContrato();
        public FormContrato()
        {
            InitializeComponent();
        }
        private void cargaContrato()
        {
            CNContrato contrato = new CNContrato();
            dgContrato.DataSource = contrato.mostrarContrato();
        }
        private void FormContrato_Load(object sender, EventArgs e)
        {
            cargaContrato();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objetoContrato.Tipo = txtTipo.Text;
            objetoContrato.NomInteresado = txtNombreC.Text;
            objetoContrato.ApInteresado = txtApellidoC.Text;
            objetoContrato.FechaInicio = txtFechaIni.Text;
            objetoContrato.FechaFin = txtFecahFin.Text;

            if (editar == true)
            {
                objetoContrato.IdContrato = idContrato;
                try
                {
                    objetoContrato.editarContrato();
                    MessageBox.Show("Se editaron los datos correctamente.");                    
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo fallo debido a: "+ex);
                }
            }
            else
            {
                try
                {
                    objetoContrato.insertaContrato();
                    MessageBox.Show("Se inserto los datos correctamente.");                    
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo fallo debido a: " + ex);
                }
            }
            cargaContrato();
            txtTipo.Clear();
            txtNombreC.Clear();
            txtApellidoC.Clear();
            txtFechaIni.Clear();
            txtFecahFin.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {            
            if(dgContrato.SelectedRows.Count > 0)
            {
                editar = true;
                txtTipo.Text = dgContrato.CurrentRow.Cells["tipo"].Value.ToString();
                txtNombreC.Text = dgContrato.CurrentRow.Cells["nomInteresado"].Value.ToString();
                txtApellidoC.Text = dgContrato.CurrentRow.Cells["apInteresado"].Value.ToString();
                txtFechaIni.Text = dgContrato.CurrentRow.Cells["fechaInicio"].Value.ToString();
                txtFecahFin.Text = dgContrato.CurrentRow.Cells["fechaFin"].Value.ToString();
                idContrato = dgContrato.CurrentRow.Cells["idContrato"].Value.ToString();                
            }
            else
            {
                MessageBox.Show("Seleccione la fila a editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            if(dgContrato.SelectedRows.Count > 0)
            {
                objetoContrato.IdContrato = dgContrato.CurrentRow.Cells["idContrato"].Value.ToString();
                objetoContrato.eliminarContrato();
                MessageBox.Show("El registro fue eliminado exitosamente");
                cargaContrato();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desee eliminar");
            }
        }
    }
}
