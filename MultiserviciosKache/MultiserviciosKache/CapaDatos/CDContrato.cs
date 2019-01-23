using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDContrato
    {
        private int id;
        private string tipo;
        private string nomInteresado;
        private string apInteresado;
        private DateTime fechainicio;
        private DateTime fechaFin;

        CDConexion conexion = new CDConexion();
        SqlDataReader leer;
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();

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

        public string NomInteresado
        {
            get
            {
                return nomInteresado;
            }

            set
            {
                nomInteresado = value;
            }
        }

        public string ApInteresado
        {
            get
            {
                return apInteresado;
            }

            set
            {
                apInteresado = value;
            }
        }

        public DateTime Fechainicio
        {
            get
            {
                return fechainicio;
            }

            set
            {
                fechainicio = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
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

        public DataTable mostrar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT * FROM contrato";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }
        public void insertar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "INSERT INTO contrato VALUES('"+Tipo+"', '"+NomInteresado+"', '"+ApInteresado+"', '"+Fechainicio+"', '"+FechaFin+"')";
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
        public void editar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE contrato SET tipo='"+Tipo+"', nomInteresado='"+NomInteresado+"', apInteresado='"+ApInteresado+"', fechaInicio='"+Fechainicio+"', fechaFin='"+FechaFin+"' WHERE idContrato="+Id;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
        public void eliminar()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "DELETE FROM contrato WHERE idContrato=" + Id;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }
    }
}
