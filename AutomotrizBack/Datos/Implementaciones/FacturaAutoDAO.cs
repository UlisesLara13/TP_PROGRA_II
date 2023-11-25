using AutomotrizBack.Datos.Interfaces;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Datos.Implementaciones
{
    public class FacturaAutoDAO : IFacturaAutoDAO
    {

        public bool Crear(Factura_Autos oFacturaAuto)
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
                comando.CommandText = "SP_INSERTAR_MAESTRO";
                comando.Parameters.AddWithValue("@fechapago", oFacturaAuto.FechaPago);
                comando.Parameters.AddWithValue("@intereses", oFacturaAuto.Intereses);
                comando.Parameters.AddWithValue("@descuento", oFacturaAuto.Descuentos);
                comando.Parameters.AddWithValue("@id_cliente", oFacturaAuto.Cliente.ClienteId);
                comando.Parameters.AddWithValue("@id_forma_pago", oFacturaAuto.FormaPago.FormaPagoId);
                comando.Parameters.AddWithValue("@id_forma_envio", oFacturaAuto.FormaEnvio.FormaEnvioId);


                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@factura_nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int facturaNro = (int)parametro.Value;
                SqlCommand cmdDetalle;

                foreach (Detalle_Factura_Autos dp in oFacturaAuto.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_factura_auto", facturaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_auto", dp.Auto.AutoId);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", dp.CalcularSubtotal());
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }
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

        public List<Factura_Autos> ObtenerFacturaAutoCbo()
        {
            List<Factura_Autos> lst = new List<Factura_Autos>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FACTURA_AUTO_UPDATE");

            foreach (DataRow fila in tabla.Rows)
            {

                int facturaId = int.Parse(fila["FacturaAutoID"].ToString());
                Factura_Autos facturaExistente = lst.FirstOrDefault(f => f.FacturaAutoId == facturaId);
                if (facturaExistente == null)
                {
                    Autos auto = new Autos();

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

                    Detalle_Factura_Autos dfa = new Detalle_Factura_Autos();
                    dfa.DetalleFacturaAutoId = int.Parse(fila["DetalleFacturaAutoID"].ToString());
                    dfa.Subtotal = float.Parse(fila["Subtotal"].ToString());
                    dfa.Cantidad = int.Parse(fila["Cantidad"].ToString());
                    dfa.Auto = a;


                    Provincias p = new Provincias();
                    p.ProvinciaId = int.Parse(fila["ProvinciaID"].ToString());
                    p.Nombre = fila["Provincia"].ToString();

                    Localidades l = new Localidades();
                    l.LocalidadId = int.Parse(fila["LocalidadID"].ToString());
                    l.Nombre = fila["Localidad"].ToString();
                    l.Provincia = p;

                    Barrios b = new Barrios();
                    b.BarrioId = int.Parse(fila["BarrioID"].ToString());
                    b.Barrio = fila["Barrio"].ToString();
                    b.Localidad = l;

                    Tipos_Cliente tcl = new Tipos_Cliente();
                    tcl.TipoClienteId = int.Parse(fila["TipoClienteID"].ToString());
                    tcl.TipoCliente = fila["TipoCliente"].ToString();

                    Clientes cl = new Clientes();
                    cl.ClienteId = int.Parse(fila["ClienteID"].ToString());
                    cl.RazonSocial = fila["Razon_Social"].ToString();
                    cl.Calle = fila["Calle"].ToString();
                    cl.Altura = int.Parse(fila["Altura"].ToString());
                    cl.CuitCuil = int.Parse(fila["CUIT_CUIL"].ToString());

                    Forma_Pago fp = new Forma_Pago();
                    fp.FormaPagoId = int.Parse(fila["FormaPagoId"].ToString());
                    fp.FormaPago = fila["FormaPago"].ToString();

                    Forma_Envio fe = new Forma_Envio();
                    fe.FormaEnvioId = int.Parse(fila["FormaEnvioID"].ToString());
                    fe.FormaEnvio = fila["FormaEnvio"].ToString();

                    Factura_Autos f = new Factura_Autos();
                    f.FacturaAutoId = int.Parse(fila["FacturaAutoID"].ToString());
                    f.FechaFactura = DateTime.Parse(fila["FechaFactura"].ToString());
                    f.FechaPago = DateTime.Parse(fila["FechaPago"].ToString());
                    f.Intereses = float.Parse(fila["Intereses"].ToString());
                    f.Descuentos = float.Parse(fila["Descuento"].ToString());

                    f.FormaEnvio = fe;
                    f.FormaPago = fp;
                    f.Cliente = cl;

                    f.AgregarDetalle(dfa);
                    facturaExistente = f;
                    lst.Add(f);
                }
                else
                {
                    Autos auto = new Autos();

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

                    Detalle_Factura_Autos dfa = new Detalle_Factura_Autos();
                    dfa.DetalleFacturaAutoId = int.Parse(fila["DetalleFacturaAutoID"].ToString());
                    dfa.Subtotal = float.Parse(fila["Subtotal"].ToString());
                    dfa.Cantidad = int.Parse(fila["Cantidad"].ToString());
                    dfa.Auto = a;
                    facturaExistente.AgregarDetalle(dfa);
                }
            }


                
            return lst;
        }


        public Factura_Autos ObtenerFacturaAutoNro(int numero)
        {
            Factura_Autos f = null;
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", numero));
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FACTURA_AUTO", lst);

            foreach (DataRow fila in tabla.Rows)
            {
                Autos auto = new Autos();

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

                Detalle_Factura_Autos dfa = new Detalle_Factura_Autos();
                dfa.DetalleFacturaAutoId = int.Parse(fila["DetalleFacturaAutoID"].ToString());
                dfa.Subtotal = float.Parse(fila["subtotal"].ToString());
                dfa.Cantidad = int.Parse(fila["cantidad"].ToString());
                dfa.Auto = a;


                Provincias p = new Provincias();
                p.ProvinciaId = int.Parse(fila["provinciaId"].ToString());
                p.Nombre = fila["nombre"].ToString();

                Localidades l = new Localidades();
                l.LocalidadId = int.Parse(fila["LocalidadId"].ToString());
                l.Nombre = fila["nombre"].ToString();
                l.Provincia = p;

                Barrios b = new Barrios();
                b.BarrioId = int.Parse(fila["barrioId"].ToString());
                b.Barrio = fila["nombre"].ToString();
                b.Localidad = l;

                Tipos_Cliente tcl = new Tipos_Cliente();
                tcl.TipoClienteId = int.Parse(fila["tipoId"].ToString());
                tcl.TipoCliente = fila["tipo"].ToString();

                Clientes cl = new Clientes();
                cl.ClienteId = int.Parse(fila["clieteId"].ToString());
                cl.RazonSocial = fila["razon_social"].ToString();
                cl.Calle = fila["calle"].ToString();
                cl.Altura = int.Parse(fila["altura"].ToString());
                cl.CuitCuil = int.Parse(fila["cuit_cuil"].ToString());

                Forma_Pago fp = new Forma_Pago();
                fp.FormaPagoId = int.Parse(fila["formaPagoId"].ToString());
                fp.FormaPago = fila["formaPago"].ToString();

                Forma_Envio fe = new Forma_Envio();
                fe.FormaEnvioId = int.Parse(fila["formaEnvioId"].ToString());
                fe.FormaEnvio = fila["formaEnvio"].ToString();

                f = new Factura_Autos();
                f.FacturaAutoId = int.Parse(fila["facturaAutoId"].ToString());
                f.FechaFactura = DateTime.Parse(fila["fechaFactura"].ToString());
                f.FechaPago = DateTime.Parse(fila["fechaPago"].ToString());
                f.Intereses = float.Parse(fila["intereses"].ToString());
                f.Descuentos = float.Parse(fila["descuento"].ToString());

                f.FormaEnvio = fe;
                f.FormaPago = fp;
                f.Cliente = cl;

                f.AgregarDetalle(dfa);
            }
            return f;
        }

        public DataTable ObtenerEscalarFecha(string sp, int id, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            tabla = HelperDAO.ObtenerInstancia().ConsultarPorEscalarConFechas(sp, id,desde,hasta);
            return tabla;
        }



        public List<Factura_AutosAPI> ObtenerFacturaAuto()
        {
            List <Factura_AutosAPI> lst = new List<Factura_AutosAPI>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FACTURA_AUTO_CBO");

            foreach (DataRow fila in tabla.Rows)
            {
                Factura_AutosAPI f = new Factura_AutosAPI();

                f.FacturaAutoId = int.Parse(fila["FacturaAutoID"].ToString());
                f.FechaFactura = DateTime.Parse(fila["FechaFactura"].ToString());
                f.FechaPago = DateTime.Parse(fila["FechaPago"].ToString());
                f.Intereses = float.Parse(fila["Intereses"].ToString());
                f.Descuentos = float.Parse(fila["Descuento"].ToString());
                f.Cliente = fila["Razon_Social"].ToString();
                f.FormaEnvio = fila["FormaEnvio"].ToString();
                f.FormaPago = fila["FormaPago"].ToString();
                f.alias = fila["alias"].ToString();
                lst.Add(f);
            }
            return lst;
        }

        public Factura_AutosAPI ObtenerFacturaAutoNroAPI(int id)
        {

            Factura_AutosAPI f = null;
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", id));
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FACTURA_AUTO", lst);

            foreach (DataRow fila in tabla.Rows)
            {
                f = new Factura_AutosAPI();

                f.FacturaAutoId = int.Parse(fila["FacturaAutoID"].ToString());
                f.FechaFactura = DateTime.Parse(fila["FechaFactura"].ToString());
                f.FechaPago = DateTime.Parse(fila["FechaPago"].ToString());
                f.Intereses = float.Parse(fila["Intereses"].ToString());
                f.Descuentos = float.Parse(fila["Descuento"].ToString());
                f.Cliente = fila["Razon_Social"].ToString();
                f.FormaEnvio = fila["FormaEnvio"].ToString();
                f.FormaPago = fila["FormaPago"].ToString();


            }
            return f;
        }

        public List<Detalle_Factura_Autos> ObtenerDetallesFacturaAutoNro(int id)
        {
            List<Detalle_Factura_Autos> detalles = new List<Detalle_Factura_Autos>();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", id));
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FACTURA_DETALLE", lst);

            foreach (DataRow fila in tabla.Rows)
            {
                Detalle_Factura_Autos detalle = new Detalle_Factura_Autos();

                Autos auto = new Autos();

                Modelos mo = new Modelos();
                Colores co = new Colores();
                Tipos_Motor tm = new Tipos_Motor();
                Tipo_Transmision tt = new Tipo_Transmision();
                Tipos_Combustible tc = new Tipos_Combustible();
                Marcas ma = new Marcas();
                Tipos t = new Tipos();

                int idauto = Convert.ToInt32(fila["AutoID"].ToString());
                int año = Convert.ToInt32(fila["Año"].ToString());
                int capacidad = Convert.ToInt32(fila["Capacidad"].ToString());
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

                float pre_unitario = float.Parse(fila["pre_unitario"].ToString());

                Autos a = new Autos(idauto, año, capacidad, nro_puertas, nro_cilindros, mo, co, tm, tt, tc, ma, t, pre_unitario);

                detalle.DetalleFacturaAutoId = int.Parse(fila["DetalleFacturaAutoID"].ToString());
                detalle.Auto = a;
                detalle.Subtotal = float.Parse(fila["Subtotal"].ToString());
                detalle.Cantidad = int.Parse(fila["Cantidad"].ToString());



                detalles.Add(detalle);

            }

            return detalles;
        }


        public List<Clientes> ObtenerClientesCbo()
        {
            List<Clientes> lClientes = new List<Clientes>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_CLIENTES");
            foreach (DataRow fila in tabla.Rows)
            {

                Barrios b = new Barrios();
                Localidades l = new Localidades();
                Provincias p = new Provincias();
                Tipos_Cliente tc = new Tipos_Cliente();
                Tipos_Contactos tcc = new Tipos_Contactos();
                Contactos contacto = new Contactos();


                int id = Convert.ToInt32(fila["ClienteID"].ToString());
                string rs = fila["Razon_Social"].ToString();
                string calle = fila["Calle"].ToString();
                int altura = Convert.ToInt32(fila["Altura"].ToString());
                int cuil = Convert.ToInt32(fila["CUIT_CUIL"]);

                p.ProvinciaId = Convert.ToInt32(fila["ProvinciaID"].ToString());
                p.Nombre = fila["Nombre"].ToString();

                l.LocalidadId = Convert.ToInt32(fila["LocalidadID"].ToString());
                l.Nombre = fila["Nombre"].ToString();
                l.Provincia = p;


                b.BarrioId = Convert.ToInt32(fila["BarrioID"].ToString());
                b.Barrio = fila["Nombre"].ToString();
                b.Localidad = l;

                tc.TipoClienteId = Convert.ToInt32(fila["TipoClienteID"].ToString());
                tc.TipoCliente = fila["TipoCliente"].ToString();


                tcc.TipoContactoId = Convert.ToInt32(fila["TipoContactoID"]);
                tcc.TipoContacto = fila["TipoContacto"].ToString();

                contacto.ContactoId = Convert.ToInt32(fila["ContactoID"]);
                contacto.Contacto = fila["Contacto"].ToString();
                contacto.Tipo = tcc;

                Clientes c = new Clientes(id, rs, calle, altura, cuil, b, tc, contacto);
                lClientes.Add(c);

            }

            return lClientes;

        }

        public List<ClientesAPI> ObtenerClientes()
        {
            List<ClientesAPI> lClientesAPI = new List<ClientesAPI>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_CLIENTES");
            foreach (DataRow fila in tabla.Rows)
            {


                int id = Convert.ToInt32(fila["ClienteID"].ToString());
                string rs = fila["Razon_Social"].ToString();
                string calle = fila["Calle"].ToString();
                int altura = Convert.ToInt32(fila["Altura"].ToString());
                int cuit = Convert.ToInt32(fila["CUIT_CUIL"].ToString());
                string barrio = fila["Nombre"].ToString();
                string tipo = fila["TipoCliente"].ToString();
                string contacto = fila["Contacto"].ToString();
                string alias = fila["alias"].ToString();


                ClientesAPI c = new ClientesAPI(id, rs, calle, altura, cuit, barrio, tipo, contacto,alias);
                lClientesAPI.Add(c);

            }

            return lClientesAPI;

        }





        public List<Forma_Envio> ObtenerFormaEnvio()
        {
            List<Forma_Envio> lForma_Envio = new List<Forma_Envio>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FORMAS_ENVIO");
            foreach (DataRow fila in tabla.Rows)
            {
                int id = int.Parse(fila["FormaEnvioID"].ToString());
                string envio = fila["FormaEnvio"].ToString();
                Forma_Envio fm = new Forma_Envio(id,envio);

                lForma_Envio.Add(fm);
            }


            return lForma_Envio;
        }

        public List<Forma_Pago> ObtenerFormaPago()
        {
            List<Forma_Pago> lForma_Pago = new List<Forma_Pago>();
            DataTable tabla = HelperDAO.ObtenerInstancia().Consultar("SP_CONSULTAR_FORMAS_PAGO");
            foreach (DataRow fila in tabla.Rows)
            {
                int id = int.Parse(fila["FormaPagoID"].ToString());
                string pago = fila["FormaPago"].ToString();
                Forma_Pago fp = new Forma_Pago(id, pago);

                lForma_Pago.Add(fp);
            }


            return lForma_Pago;
        }

        public bool Eliminar_FacturaAuto(int nro_factura)
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
                comando.CommandText = "DELETE_FACTURA_AUTO";
                comando.Parameters.AddWithValue("@nro_factura", nro_factura);
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

        public bool Eliminar_Detalle(int nro_detalle)
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
                comando.CommandText = "SP_ELIMINAR_DETALLE";
                comando.Parameters.AddWithValue("@ID", nro_detalle);
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


        public int ObtenerProximoNro()
        {
            return HelperDAO.ObtenerInstancia().ConsultarEscalar("SP_PROXIMO_ID", "@next");
        }

        public bool ActualizarFactura(Factura_Autos oFactura)
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
                comando.CommandText = "SP_MODIFICAR_MAESTRO";
                comando.Parameters.AddWithValue("@factura_nro", oFactura.FacturaAutoId);
                comando.Parameters.AddWithValue("@fechapago", oFactura.FechaPago);
                comando.Parameters.AddWithValue("@intereses", oFactura.Intereses);
                comando.Parameters.AddWithValue("@descuento", oFactura.Descuentos);
                comando.Parameters.AddWithValue("@id_cliente", oFactura.Cliente.ClienteId);
                comando.Parameters.AddWithValue("@id_forma_pago", oFactura.FormaPago.FormaPagoId);
                comando.Parameters.AddWithValue("@id_forma_envio", oFactura.FormaEnvio.FormaEnvioId);

                comando.ExecuteNonQuery();


                SqlCommand cmdDetalle;

                foreach (Detalle_Factura_Autos dp in oFactura.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_factura_auto", oFactura.FacturaAutoId);
                    cmdDetalle.Parameters.AddWithValue("@id_auto", dp.Auto.AutoId);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", dp.CalcularSubtotal());
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }
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
    }
}
