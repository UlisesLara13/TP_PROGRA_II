using AutomotrizBack.Datos.Interfaces;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.Facturas;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Datos.Implementaciones
{
    public class AutoDAO : IAutoDAO
    {
        public List<AutosAPI> ObtenerAutos()
        {
            List<AutosAPI> lAutosAPI = new List<AutosAPI>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_AUTOS");
            foreach (DataRow fila in tabla.Rows)
            {

                int id = Convert.ToInt32(fila["AutoID"].ToString());
                int año = Convert.ToInt32(fila["Año"].ToString());
                decimal capacidad = Convert.ToDecimal(fila["Capacidad"].ToString());
                int nro_cilindros = Convert.ToInt32(fila["NroCilindros"].ToString());
                int nro_puertas = Convert.ToInt32(fila["NroPuertas"].ToString());
                string modelo = fila["Modelo"].ToString();
                string color = fila["Color"].ToString();       
                string motor = fila["Motor"].ToString();
                string tipotransmision = fila["TipoTransmision"].ToString();
                string tipocombustible = fila["TipoCombustible"].ToString();
                string marca = fila["Marca"].ToString();
                string tipo = fila["Tipo"].ToString();
                float pre_unitario = float.Parse(fila["precio_unitario"].ToString());
                string alias = fila["alias"].ToString();


                AutosAPI a = new AutosAPI(id, año, capacidad, nro_puertas, nro_cilindros, modelo, color,modelo, tipotransmision, tipocombustible, marca, tipo, pre_unitario,alias);
                lAutosAPI.Add(a);
            }


            return lAutosAPI;
        }


        public List<Autos> ObtenerAutosCbo()
        {
            List<Autos> lAutos = new List<Autos>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_AUTOS");
            foreach (DataRow fila in tabla.Rows)
            {
                Modelos mo = new Modelos();
                Colores co = new Colores();
                Tipos_Motor tm = new Tipos_Motor();
                Tipo_Transmision tt = new Tipo_Transmision();
                Tipos_Combustible tc = new Tipos_Combustible();
                Marcas ma = new Marcas();
                Tipos t = new Tipos();


                int id = Convert.ToInt32(fila["AutoID"].ToString());
                int año = Convert.ToInt32(fila["Año"].ToString());
                decimal capacidad = Convert.ToDecimal(fila["Capacidad"].ToString());
                int nro_cilindros = Convert.ToInt32(fila["NroCilindros"].ToString());
                int nro_puertas = Convert.ToInt32(fila["NroPuertas"].ToString());

                mo.ModeloId = Convert.ToInt32(fila["ModeloID"].ToString());
                mo.Modelo = fila["Modelo"].ToString();

                co.ColorId = Convert.ToInt32(fila["ColorID"].ToString());
                co.Color = fila["Color"].ToString();

                tm.MotorID = Convert.ToInt32(fila["Motor_ID"].ToString());
                tm.Motor = fila["Motor"].ToString();

                tt.TipoTransmisionId = Convert.ToInt32(fila["Tipo_TransmisionID"].ToString());
                tt.TipoTransmision = fila["TipoTransmision"].ToString();

                tc.TipoCombustibleID = Convert.ToInt32(fila["Tipo_CombustibleID"].ToString());
                tc.TipoCombustible = fila["TipoCombustible"].ToString();

                ma.MarcaId = Convert.ToInt32(fila["MarcaID"].ToString());
                ma.Marca = fila["Marca"].ToString();

                t.TipoId = Convert.ToInt32(fila["TipoID"].ToString());
                t.Tipo = fila["Tipo"].ToString();

                float pre_unitario = float.Parse(fila["precio_unitario"].ToString());


                Autos a = new Autos(id, año, capacidad, nro_puertas, nro_cilindros, mo, co, tm, tt, tc, ma, t, pre_unitario);
                lAutos.Add(a);
            }


            return lAutos;
        }

        public List<Modelos> ObtenerModelos()
        {
            List<Modelos> lModelos = new List<Modelos>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_MODELOS");
            foreach (DataRow fila in tabla.Rows)
            {
                int id = int.Parse(fila["ModeloID"].ToString());
                string modelo = fila["Modelo"].ToString();
                Modelos m = new Modelos(modelo,id);

                lModelos.Add(m);
            }


            return lModelos;
        }

        public bool EliminarAuto(int id)
        {
            bool resultado = true;

            SqlTransaction t = null;
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ELIMINAR_AUTO";
                comando.Parameters.AddWithValue("@AutoId", id);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }

        public List<Tipos_Motor> ObtenerMotores()
        {
            List<Tipos_Motor> lMotores = new List<Tipos_Motor>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPO_MOTOR");
            foreach (DataRow fila in tabla.Rows)
            {

                int id = Convert.ToInt32(fila["Motor_ID"].ToString());
                string marca = (fila["Motor"].ToString());

                Tipos_Motor m = new Tipos_Motor(marca,id);
                lMotores.Add(m);
            }


            return lMotores;
        }

        public List<Marcas> ObtenerMarcas()
        {
            List<Marcas> lMarcas = new List<Marcas>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_MARCAS");
            foreach (DataRow fila in tabla.Rows)
            {



                int id = Convert.ToInt32(fila["MarcaID"].ToString());
                string marca = (fila["Marca"].ToString());


                Marcas m = new Marcas(id, marca);
                lMarcas.Add(m);
            }


            return lMarcas;
        }

        public DataTable ObtenerConsultasParametros(string sp, List<Parametro> parametros)
        {
            DataTable tabla = new DataTable();
            tabla = HelperDAO.ObtenerInstancia().Consultar(sp, parametros);
            return tabla;
        }

        public List<Colores> ObtenerColores()
        {
            List<Colores> lColores = new List<Colores>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_COLORES");
            foreach (DataRow fila in tabla.Rows)
            {



                int id = Convert.ToInt32(fila["ColorID"].ToString());
                string color = (fila["Color"].ToString());


                Colores c = new Colores(id, color);
                lColores.Add(c);
            }


            return lColores;
        }
        public DataTable ObtenerConsulta(string sp)
        {
            DataTable tabla = new DataTable();
            tabla = HelperDAO.ObtenerInstancia().Consultar(sp);
            return tabla;
        }
        public List<Tipos_Combustible> ObtenerCombustible()
        {
            List<Tipos_Combustible> lTipoCombustible = new List<Tipos_Combustible>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPO_COMBUSTIBLE");
            foreach (DataRow fila in tabla.Rows)
            {


                int id = Convert.ToInt32(fila["Tipo_CombustibleID"].ToString());
                string nombre = (fila["TipoCombustible"].ToString());


                Tipos_Combustible tc = new Tipos_Combustible(nombre, id);
                lTipoCombustible.Add(tc);
            }

            return lTipoCombustible;
        }
        public List<Tipos> ObtenerTipos()
        {
            List<Tipos> lTipos = new List<Tipos>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPOS");
            foreach (DataRow fila in tabla.Rows)
            {


                int id = Convert.ToInt32(fila["TipoID"].ToString());
                string nombre = (fila["Tipo"].ToString());


                Tipos t = new Tipos(nombre,id);
                lTipos.Add(t);
            }


            return lTipos;
        }

        public List<Tipo_Transmision> ObtenerTransmisiones()
        {
            List<Tipo_Transmision> lTransmision = new List<Tipo_Transmision>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_TIPO_TRANSMISION");
            foreach (DataRow fila in tabla.Rows)
            {



                int id = Convert.ToInt32(fila["Tipo_TransmisionID"].ToString());
                string transmision = (fila["TipoTransmision"].ToString());


                Tipo_Transmision tm = new Tipo_Transmision(transmision,id);
                lTransmision.Add(tm);
            }


            return lTransmision;
        }

        public bool CrearAuto(Autos oAuto)
        {
            bool resultado = true;

            SqlTransaction t = null;
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_AUTO";
                comando.Parameters.AddWithValue("@año", oAuto.Año);
                comando.Parameters.AddWithValue("@capacidad", oAuto.Capacidad);
                comando.Parameters.AddWithValue("@nro_puertas", oAuto.NroPuertas);
                comando.Parameters.AddWithValue("@nro_cilindros", oAuto.NroCiliendros);
                comando.Parameters.AddWithValue("@precio_unitario", oAuto.PrecioUnitario);
                comando.Parameters.AddWithValue("@id_ModeloId", oAuto.Modelo.ModeloId);
                comando.Parameters.AddWithValue("@id_ColorId", oAuto.Color.ColorId);
                comando.Parameters.AddWithValue("@id_Tipos_MotorId", oAuto.Motor.MotorID);
                comando.Parameters.AddWithValue("@id_Tipos_TransmisionId", oAuto.Transmision.TipoTransmisionId);
                comando.Parameters.AddWithValue("@id_Tipos_CombustibleId", oAuto.Combustible.TipoCombustibleID);
                comando.Parameters.AddWithValue("@id_MarcaId", oAuto.Marca.MarcaId);
                comando.Parameters.AddWithValue("@id_TipoId", oAuto.Tipo.TipoId);


                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@AutoId";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;

        }

        

        public bool ActualizarAuto(Autos oAuto)
        {
            bool resultado = true;

            SqlTransaction t = null;
            SqlConnection conexion = HelperDAO.ObtenerInstancia().ObtenerConexion();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_MODIFICAR_AUTO";
                comando.Parameters.AddWithValue("@AutoId", oAuto.AutoId);
                comando.Parameters.AddWithValue("@Año", oAuto.Año);
                comando.Parameters.AddWithValue("@Capacidad", oAuto.Capacidad);
                comando.Parameters.AddWithValue("@NroPuertas", oAuto.NroPuertas);
                comando.Parameters.AddWithValue("@ModeloId", oAuto.Modelo.ModeloId);
                comando.Parameters.AddWithValue("@ColorId", oAuto.Color.ColorId);
                comando.Parameters.AddWithValue("@MotorId", oAuto.Motor.MotorID);
                comando.Parameters.AddWithValue("@TransmisionId", oAuto.Transmision.TipoTransmisionId);
                comando.Parameters.AddWithValue("@CombustibleId", oAuto.Combustible.TipoCombustibleID);
                comando.Parameters.AddWithValue("@MarcaId", oAuto.Marca.MarcaId);
                comando.Parameters.AddWithValue("@TipoId", oAuto.Tipo.TipoId);
                comando.Parameters.AddWithValue("@precio_unitario", oAuto.PrecioUnitario);

                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }


        public int ObtenerProximoAuto()
        {
            return HelperDAO.ObtenerInstancia().ConsultarEscalar("SP_PROXIMO_AUTO", "@next");
        }

        public DataTable ObtenerPorEscalar(string sp, int id)
        {
            DataTable tabla = new DataTable();
            tabla = HelperDAO.ObtenerInstancia().ConsultarPorEscalar(sp, id);
            return tabla;
        }

    }
}
