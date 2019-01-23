using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class CDItem
    {
        private int id;
        private string tipo;
        private int cantidad;
        private int alquilado;

        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;
        private SqlCommand comando = new SqlCommand();
        private DataTable tabla = new DataTable();

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

        public int Cantidad
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

        public int Alquilado
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
        public DataTable mostrar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT * FROM mobiliario";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }
        public void insertar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "INSERT INTO mobiliario VALUES('"+Tipo+"', "+Cantidad+", "+Alquilado+")";
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
        public void editar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE mobiliario SET tipo='"+Tipo+"', cantidad="+Cantidad+", alquilado="+Alquilado+" WHERE idMobiliario="+Id;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
        public void eliminar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "DELETE FROM mobiliario WHERE idMobiliario="+Id;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
    }
}
