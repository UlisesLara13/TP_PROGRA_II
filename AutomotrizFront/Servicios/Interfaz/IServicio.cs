
using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomotrizFront.Servicios.Interfaz
{
    public interface IServicio
    {
        int TraerProximaFactura();
        int TraerProximoAuto();
        List<Modelos> TraerModelos();

        DataTable ObtenerConsultaID(string sp, int id);

        bool CrearFactura(Factura_Autos oFactura);

        DataTable ObtenerEscalarFecha(string sp, int id, DateTime desde, DateTime hasta);

        bool CrearAuto(Autos oAuto);
        bool ActualizarAuto(Autos oAuto);
        bool EliminarAuto(int id);
        List<AutosAPI> TraerAutos();

        DataTable ObtenerConsultaParametros(string sp, List<Parametro> parametros);
        DataTable ObtenerConsulta(string sp);
        List<Clientes> ObtenerClientesCbo();
        List<Factura_Autos> ObtenerFacturaAutosCbo();
        List<Autos> TraerAutosCbo();




    }
}
