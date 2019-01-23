using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class CDEmpleado
    {
        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;

        private int id;
        private String nombre;
        private String apellido;
        private String puesto;

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

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

        public int Id
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

        public SqlDataReader iniciaSesion(int ci, String contrasenia)
        {
            String sql = "SELECT * FROM administrador WHERE ci="+ci+" AND contrasenia ='"+contrasenia+"'";            
            comando.Connection = conexion.abrirConexion();            
            comando.CommandText = sql;
            leer = comando.ExecuteReader();
            
            return leer;
        }
        public DataTable mostrar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT * FROM empleado";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }

        public void insertar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "INSERT INTO empleado VALUES('" + Nombre + "', '" + Apellido + "', '" + Puesto + "', 0)";
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();            
        }
        public void editar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE empleado SET nombre='"+Nombre+"', apellido='"+Apellido+"', puesto='"+Puesto+"' WHERE idEmpleado="+Id;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
        public void eliminar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "DELETE FROM empleado WHERE idEmpleado=" + Id;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }

    }
}
