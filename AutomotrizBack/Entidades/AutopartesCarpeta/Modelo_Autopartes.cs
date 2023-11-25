using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutopartesCarpeta
{
    public class Modelo_Autopartes
    {
        public int ModeloAutoparteId { get; set; }
        public string Descripcion { get; set; }

        public Modelo_Autopartes()
        {
            ModeloAutoparteId = 0;
            Descripcion = string.Empty;
        }

        public Modelo_Autopartes(string descripcion)
        {
            this.Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
