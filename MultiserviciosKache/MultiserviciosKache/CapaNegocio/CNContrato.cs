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
    public class CNContrato
    {
        private string tipo;
        private string nomInteresado;
        private string apInteresado;
        private string fechaInicio;
        private string fechaFin;
        private string idContrato;
        CDContrato objContrato = new CDContrato();

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

        public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public string FechaFin
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

        public string IdContrato
        {
            get
            {
                return idContrato;
            }

            set
            {
                idContrato = value;
            }
        }

        public DataTable mostrarContrato()
        {
            DataTable tabla = new DataTable();
            tabla = objContrato.mostrar();
            return tabla;
        }

        public void insertaContrato()
        {            
            objContrato.Tipo = Tipo;
            objContrato.NomInteresado = NomInteresado;
            objContrato.ApInteresado = ApInteresado;
            objContrato.Fechainicio = Convert.ToDateTime(FechaInicio);
            objContrato.FechaFin = Convert.ToDateTime(FechaFin);

            objContrato.insertar();
        }
        public void editarContrato()
        {
            objContrato.Id = Convert.ToInt32(IdContrato);
            objContrato.Tipo = Tipo;            
            objContrato.NomInteresado = NomInteresado;
            objContrato.ApInteresado = ApInteresado;
            objContrato.Fechainicio = Convert.ToDateTime(FechaInicio);
            objContrato.FechaFin = Convert.ToDateTime(FechaFin);

            objContrato.editar();
        }
        public void eliminarContrato()
        {
            objContrato.Id = Convert.ToInt32(IdContrato);
            objContrato.eliminar();
        }

    }
}
