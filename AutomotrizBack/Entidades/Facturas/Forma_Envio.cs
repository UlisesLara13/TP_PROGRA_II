using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.Facturas
{
    public class Forma_Envio
    {

        public int FormaEnvioId { get; set; }
        public string FormaEnvio { get; set; }

        public Forma_Envio()
        {
            FormaEnvioId = 0;
            FormaEnvio = string.Empty;
        }

        public Forma_Envio(int id, string formaenvio)
        {
            this.FormaEnvioId = id;
            this.FormaEnvio = formaenvio;
        }


        public override string ToString() { return FormaEnvio; }
    }
}
