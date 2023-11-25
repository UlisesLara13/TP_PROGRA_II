using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AutomotrizBack.Datos
{
    public class HelperDAO
    {
        private static HelperDAO instancia;
        private SqlConnection conexion;
        private HelperDAO()
        {
            conexion = new SqlConnection(Properties.Resources.CadenaConexion);
        }

        public static HelperDAO ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDAO();
            }
            return instancia;
        }

        public int ConsultarEscalar(string nombreSP, string paramSalida)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = paramSalida;
            parametro.SqlDbType = SqlDbType.Int;
            parametro.Direction = ParameterDirection.Output;

            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();

            conexion.Close();
            return (int)parametro.Value;
        }

        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public DataTable Consultar(string nombreSP, string parametro)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            SqlParameter parameter = new SqlParameter(parametro, SqlDbType.VarChar);
            comando.Parameters.Add(parameter);
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public DataTable ConsultarPorEscalar(string nombreSP, int valorParametro)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            SqlParameter parameter = new SqlParameter("@Marcaid", SqlDbType.Int);
            parameter.Value = valorParametro;  
            comando.Parameters.Add(parameter);
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public DataTable ConsultarPorEscalarConFechas(string nombreSP, int valorParametro, DateTime fechaDesde, DateTime fechaHasta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();

            SqlParameter parameterIdCliente = new SqlParameter("@cliente", SqlDbType.Int);
            parameterIdCliente.Value = valorParametro;
            comando.Parameters.Add(parameterIdCliente);

            SqlParameter parameterFechaDesde = new SqlParameter("@desde", SqlDbType.DateTime);
            parameterFechaDesde.Value = fechaDesde;
            comando.Parameters.Add(parameterFechaDesde);

            SqlParameter parameterFechaHasta = new SqlParameter("@hasta", SqlDbType.DateTime);
            parameterFechaHasta.Value = fechaHasta;
            comando.Parameters.Add(parameterFechaHasta);

            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public DataTable Consultar(string nombreSP, List<Parametro> lstParametros)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            comando.Parameters.Clear();
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public DataTable ConsultarFechas(string nombreSP, List<Parametro> lstParametros)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            comando.Parameters.Clear();
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }


        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
