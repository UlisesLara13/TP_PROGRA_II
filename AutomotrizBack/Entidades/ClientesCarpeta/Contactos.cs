using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Contactos
    {
        public int ContactoId { get; set; }
        public string Contacto { get; set; }
        public Tipos_Contactos Tipo { get; set; }
        public Contactos()
        {
            ContactoId = 0;
            Contacto = string.Empty;
            Tipo = new Tipos_Contactos();
        }

        public Contactos(string contacto, Tipos_Contactos tipo)
        {
            Contacto = contacto;
            Tipo = tipo;
        }

        public override string ToString() { return Contacto; }
    }
}
