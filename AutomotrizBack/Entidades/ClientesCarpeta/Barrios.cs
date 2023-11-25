using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Barrios
    {
        public int BarrioId { get; set; }
        public string Barrio { get; set; }

        public Localidades Localidad { get; set; }

        public Barrios()
        {
            BarrioId = 0;
            Barrio = string.Empty;
            Localidad = new Localidades();
        }

        public Barrios(string barrio, Localidades localidad)
        {
            this.Barrio = barrio;
            this.Localidad = localidad;
        }

        public override string ToString()
        {
            return Barrio + ", " + Localidad.ToString();
        }
    }
}
