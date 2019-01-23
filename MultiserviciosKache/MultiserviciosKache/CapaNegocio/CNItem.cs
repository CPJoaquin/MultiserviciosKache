using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class CNItem
    {
        private string id;
        private string tipo;
        private string cantidad;
        private string alquilado;

        private CDItem objetoItem = new CapaDatos.CDItem();

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public string Alquilado
        {
            get
            {
                return alquilado;
            }

            set
            {
                alquilado = value;
            }
        }
        public DataTable mostrarMobiliario()
        {
            DataTable tabla = new DataTable();
            tabla = objetoItem.mostrar();
            return tabla;
        }
        public void insertar()
        {            
            objetoItem.Tipo = Tipo;
            objetoItem.Cantidad = Convert.ToInt32(Cantidad);
            objetoItem.Alquilado = Convert.ToInt32(Alquilado);

            objetoItem.insertar();
        }
        public void editar()
        {
            objetoItem.Id = Convert.ToInt32(Id);
            objetoItem.Tipo = Tipo;
            objetoItem.Cantidad = Convert.ToInt32(Cantidad);
            objetoItem.Alquilado = Convert.ToInt32(Alquilado);

            objetoItem.editar();
        }
        public void  eliminar()
        {
            objetoItem.Id = Convert.ToInt32(Id);

            objetoItem.eliminar();
        }
    }
}
