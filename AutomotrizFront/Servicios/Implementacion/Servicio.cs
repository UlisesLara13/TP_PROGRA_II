
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomotrizBack.Datos;
using AutomotrizBack.Datos.Implementaciones;
using AutomotrizBack.Datos.Interfaces;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using AutomotrizFront.Servicios.Interfaz;

namespace AutomotrizFront.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IAutoDAO daoAuto;
        private IFacturaAutoDAO daoFactura;

        public Servicio()
        {
            daoAuto = new AutoDAO();
            daoFactura = new FacturaAutoDAO();
        }
        public bool ActualizarAuto(Autos oAuto)
        {
            return daoAuto.ActualizarAuto(oAuto);
        }

        public bool CrearAuto(Autos oAuto)
        {
            return daoAuto.CrearAuto(oAuto);
        }

        public bool CrearFactura(Factura_Autos oFactura)
        {
            return daoFactura.Crear(oFactura);
        }

        public bool EliminarAuto(int id)
        {
            return daoAuto.EliminarAuto(id);
        }

        public List<Autos> TraerAutosCbo()
        {
            return daoAuto.ObtenerAutosCbo();
        }

        public List<Factura_Autos> ObtenerFacturaAutosCbo() 
        {
            return daoFactura.ObtenerFacturaAutoCbo();
        }

        public DataTable ObtenerConsultaParametros(string sp, List<Parametro> parametros)
        {
            return daoAuto.ObtenerConsultasParametros(sp,parametros);
        }

        public DataTable ObtenerConsulta(string sp)
        {
            return daoAuto.ObtenerConsulta(sp);
        }

        public DataTable ObtenerConsultaID(string sp,int id)
        {
            return daoAuto.ObtenerPorEscalar(sp,id);
        }

        public List<AutosAPI> TraerAutos()
        {
            return daoAuto.ObtenerAutos();
        }

        public List<Modelos> TraerModelos()
        {
            return daoAuto.ObtenerModelos();
        }



        public int TraerProximaFactura()
        {
            return daoFactura.ObtenerProximoNro();
        }

        public int TraerProximoAuto()
        {
            return daoAuto.ObtenerProximoAuto();
        }

        public List<Clientes> ObtenerClientesCbo()
        {
            return daoFactura.ObtenerClientesCbo() ;
        }

        public DataTable ObtenerEscalarFecha(string sp, int id, DateTime desde, DateTime hasta)
        {
            return daoFactura.ObtenerEscalarFecha(sp, id, desde, hasta);
        }
    }
}
