using AutomotrizBack.Entidades.ClientesCarpeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Factura_Autopartes
    {
        public int FacturaAutopartesId { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public float Intereses { get; set; }
        public float Descuentos { get; set; }
        public Clientes Cliente { get; set; }
        public Forma_Envio FormaEnvio { get; set; }
        public Forma_Pago FormaPago { get; set; }
        public List<Detalle_Factura_Autopartes> Detalles { get; set; }

        public Factura_Autopartes()
        {

            Detalles = new List<Detalle_Factura_Autopartes>();

        }

        public Factura_Autopartes(DateTime fechafactura, DateTime fechapago, float intereses, float descuentos, Clientes cliente, Forma_Envio envio, Forma_Pago pago, List<Detalle_Factura_Autopartes> detalles)
        {
            FechaFactura = fechafactura;
            FechaPago = fechapago;
            Intereses = intereses;
            Descuentos = descuentos;
            Cliente = cliente;
            FormaEnvio = envio;
            FormaPago = pago;
            Detalles = detalles;
        }

        public void AgregarDetalle(Detalle_Factura_Autopartes detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }

        public float CalcularTotal()
        {
            float total = 0;

            foreach (Detalle_Factura_Autopartes d in Detalles)
            {
                d.SubtotalCalculo();
                total += d.Subtotal;
            }
            return total + (total * Intereses) - (total * Descuentos);
        }
    }
}
