using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Modelos
    {
        public int ModeloId { get; set; }
        public string Modelo { get; set; }

        public Modelos()
        {
            ModeloId = 0;
            Modelo = string.Empty;
        }

        public Modelos(string modelo, int id)
        {
            ModeloId=id;
            Modelo = modelo;
        }

        public override string ToString() { return Modelo; }
    }
}
