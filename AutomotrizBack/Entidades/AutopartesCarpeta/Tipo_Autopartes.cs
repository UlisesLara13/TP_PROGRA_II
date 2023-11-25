using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutopartesCarpeta
{
    public class Tipo_Autopartes
    {
        public int TipoAutoparteId {  get; set; }
        public string Descripcion { get; set; }

        public Tipo_Autopartes()
        {
            TipoAutoparteId = 0;
            Descripcion = string.Empty;
        }

        public Tipo_Autopartes(string descripcion)
        {
            this.Descripcion = descripcion;
        }

        public override string ToString() { return Descripcion; }
    }
}
