using AutomotrizBack.Entidades.ClientesCarpeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Factura_Autos
    {
        public int FacturaAutoId { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaPago { get; set; }
        public float Intereses { get; set; }
        public float Descuentos { get; set; }
        public Clientes Cliente { get; set; }
        public Forma_Envio FormaEnvio { get; set; }
        public Forma_Pago FormaPago { get; set; }
        public List<Detalle_Factura_Autos> Detalles { get; set; }

        public Factura_Autos()
        {

            Detalles = new List<Detalle_Factura_Autos>();

        }

        public Factura_Autos(int id,DateTime fechafactura, DateTime fechapago, float intereses, float descuentos, Clientes cliente, Forma_Envio envio, Forma_Pago pago )
        {
            FacturaAutoId = id;
            FechaFactura = fechafactura;
            FechaPago = fechapago;
            Intereses = intereses;
            Descuentos = descuentos;
            Cliente = cliente;
            FormaEnvio = envio;
            FormaPago = pago;
            Detalles = new List<Detalle_Factura_Autos>();

        }

        public void AgregarDetalle(Detalle_Factura_Autos detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }

        public float CalcularTotal(float desc,float inte)
        {
            float total = 0;
            foreach (Detalle_Factura_Autos d in Detalles)
            {
                total += d.CalcularSubtotal(desc,inte);
            }
            return total;
        }

        public override string ToString()
        {
            return this.Cliente.ToString();
        }


    }
}
