using AutomotrizBack.Entidades.AutopartesCarpeta;
using AutomotrizBack.Entidades.AutosCarpeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Detalle_Factura_Autopartes
    {

        public int DetalleFacturaAutoparteId { get; set; }
        public Autopartes Autoparte { get; set; }
        public float Subtotal { get; set; }
        public int Cantidad { get; set; }

        public Detalle_Factura_Autopartes()
        {
            DetalleFacturaAutoparteId = 0;
            Autoparte = new Autopartes();
            Subtotal = 0;
            Cantidad = 0;
        }

        public Detalle_Factura_Autopartes(int cantidad, Autopartes autoparte)
        {
            Autoparte = autoparte;
            Cantidad = cantidad;
        }

        public void SubtotalCalculo()
        {
            Subtotal = Cantidad * Autoparte.PrecioUnitario;
        }
    }
}
