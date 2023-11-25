using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Localidades
    {
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }
        public Provincias Provincia { get; set; }

        public Localidades()
        {
            LocalidadId = 0;
            Nombre = string.Empty;
            Provincia = new Provincias();
        }

        public Localidades(string nombre, Provincias provincia)
        {
            this.Provincia = provincia;
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre + ", " + Provincia.ToString();
        }
    }
}
