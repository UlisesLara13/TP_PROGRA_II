using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Datos.Interfaces
{
    public interface IFacturaAutoDAO
    {
        bool Crear(Factura_Autos oFacturaAuto);
        int ObtenerProximoNro();
        List<Forma_Envio> ObtenerFormaEnvio();

        List<Factura_AutosAPI> ObtenerFacturaAuto();
        List<Clientes> ObtenerClientesCbo();

        DataTable ObtenerEscalarFecha(string sp, int id, DateTime desde, DateTime hasta);

        List<Forma_Pago> ObtenerFormaPago();
        List<ClientesAPI> ObtenerClientes();
        Factura_AutosAPI ObtenerFacturaAutoNroAPI(int numero);

        bool Eliminar_FacturaAuto(int nro_factura);
        bool Eliminar_Detalle(int nro_detalle);
        List<Detalle_Factura_Autos> ObtenerDetallesFacturaAutoNro(int id);

        List<Factura_Autos> ObtenerFacturaAutoCbo();

        Factura_Autos ObtenerFacturaAutoNro(int numero);

        bool ActualizarFactura(Factura_Autos oFactura);

    }
}
