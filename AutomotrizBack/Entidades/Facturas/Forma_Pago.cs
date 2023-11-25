using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Forma_Pago
    {

        public int FormaPagoId { get; set; }
        public string FormaPago { get; set; }

        public Forma_Pago()
        {
            FormaPago = string.Empty;
            FormaPagoId = 0;
        }

        public Forma_Pago(int id, string formapago)
        {
            this.FormaPagoId = id;
            this.FormaPago = formapago;
        }


        public override string ToString() { return FormaPago; }
    }
}
