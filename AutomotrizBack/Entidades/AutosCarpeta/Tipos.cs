using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Tipos
    {
        public int TipoId { get; set; }
        public string Tipo { get; set; }

        public Tipos()
        {
            TipoId = 0;
            Tipo = string.Empty;
        }

        public Tipos(string tipo, int id)
        {
            Tipo = tipo;
            TipoId = id;
        }

        public override string ToString() { return Tipo; }
    }
}
