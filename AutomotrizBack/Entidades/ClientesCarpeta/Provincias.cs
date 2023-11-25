using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Provincias
    {
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }

        public Provincias()
        {
            ProvinciaId = 0;
            Nombre = string.Empty;
        }

        public Provincias(string nombre)
        {
            Nombre=nombre;
        }

        public override string ToString() { return Nombre; }
    }
}
