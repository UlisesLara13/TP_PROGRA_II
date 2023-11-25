using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Tipos_Cliente
    {
        public int  TipoClienteId { get; set; }
        public string TipoCliente { get; set; }

        public Tipos_Cliente()
        {
            TipoClienteId = 0;
            TipoCliente = string.Empty;
        }

        public Tipos_Cliente(string tipo)
        {
            this.TipoCliente = tipo;
        }

        public override string ToString() { return TipoCliente; }
    }
}
