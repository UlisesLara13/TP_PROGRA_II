using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Colores
    {

        public int ColorId { get; set; }
        public string Color { get; set; }

        public Colores()
        {
            ColorId = 0;
            Color = string.Empty;
        }

        public Colores(string color)
        {
            Color = color;
        }

        public Colores(int id, string color)
        {
            this.ColorId = id;
            Color = color;
        }

        public override string ToString() { return Color; }
    }
}
