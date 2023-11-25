using AutomotrizBack.Entidades.AutosCarpeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Detalle_Factura_Autos
    {
        public int DetalleFacturaAutoId { get; set; }
        public Autos Auto { get; set; }
        public float Subtotal { get; set; }
        public int Cantidad { get; set; }

        public Detalle_Factura_Autos()
        {
            DetalleFacturaAutoId = 0;
            Auto = new Autos();
            Subtotal = 0;
            Cantidad = 0;
        }

        public Detalle_Factura_Autos(int cantidad, Autos auto)
        {
            Auto = auto;
            Cantidad = cantidad;
        }

        public Detalle_Factura_Autos(int cantidad, Autos auto, float subtotal)
        {
            Auto = auto;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }

        public float CalcularSubtotal()
        {
            return Cantidad * Auto.PrecioUnitario;
        }

        public float CalcularSubtotal(float desc,float inte)
        {
            float subtotal = Cantidad * Auto.PrecioUnitario;
            float subtotalfinal = 0;
            desc = (Auto.PrecioUnitario * desc) / 100;
            inte = (Auto.PrecioUnitario * inte) / 100;

            subtotalfinal = subtotal + inte - desc;

            return subtotalfinal;
        }


    }
}
