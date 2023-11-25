using AutomotrizBack.Entidades.ClientesCarpeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Factura_AutosAPI
    {
        public int FacturaAutoId { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public float Intereses { get; set; }
        public float Descuentos { get; set; }
        public string Cliente { get; set; }
        public string FormaEnvio { get; set; }
        public string FormaPago { get; set; }
        public string alias { get; set; }

        public Factura_AutosAPI()
        {
            FacturaAutoId = 0;
            FechaFactura = DateTime.Today;
            FechaPago = DateTime.Today;
            Intereses = 0;
            Descuentos = 0;
            Cliente = string.Empty;
            FormaEnvio = string.Empty;
            FormaPago = string.Empty;
        }


        public Factura_AutosAPI(int id, DateTime fechafactura, DateTime fechapago, float intereses, float descuentos, string cliente, string envio, string pago, string alias)
        {
            FacturaAutoId = id;
            FechaFactura = fechafactura;
            FechaPago = fechapago;
            Intereses = intereses;
            Descuentos = descuentos;
            Cliente = cliente;
            FormaEnvio = envio;
            FormaPago = pago;
            this.alias = alias;
        }



    }
}
