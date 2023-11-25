using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Tipos_Contactos
    {
        public int TipoContactoId { get; set; }
        public string TipoContacto { get; set; }

        public Tipos_Contactos()
        {
            TipoContactoId = 0;
            TipoContacto = string.Empty;
        }

        public Tipos_Contactos(string tipocontacto)
        {
            this.TipoContacto = tipocontacto;
        }

        public override string ToString() { return TipoContacto; }
    }
}
