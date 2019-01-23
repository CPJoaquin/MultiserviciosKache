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
    public class CNEmpleado
    {
        private CDEmpleado objDato = new CDEmpleado();

        private String _ci;
        private String _contrasenia;

        private String nombre;
        private String apellido;
        private String puesto;

        public String Ci
        {
            get {     return _ci;     }
            set{     _ci = value;     }
        }

        public string Contrasenia
        {
            get {   return _contrasenia;    }
            set{  _contrasenia = value;     }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Puesto
        {
            get
            {
                return puesto;
            }

            set
            {
                puesto = value;
            }
        }

        public CNEmpleado() { }
        public SqlDataReader iniciaSesion()
        {
            SqlDataReader loguear;
            loguear = objDato.iniciaSesion(Convert.ToInt32(Ci), Contrasenia);
            return loguear;
        }

        public DataTable mostrarEmpleados()
        {
            DataTable tabla = new DataTable();
            tabla = objDato.mostrar();
            return tabla;
        }

        public void insertaEmpleado()
        {
            objDato.Nombre = Nombre;
            objDato.Apellido = Apellido;
            objDato.Puesto = Puesto;

            objDato.insertar();
        }
        public void editarEmpleado()
        {
            objDato.Nombre = Nombre;
            objDato.Apellido = Apellido;
            objDato.Puesto = Puesto;
            objDato.Id = Convert.ToInt32(Ci);
            objDato.editar();
        }
        public void eliminarEmpleado()
        {
            objDato.Id = Convert.ToInt32(Ci);
            objDato.eliminar();
        }
    }
}
