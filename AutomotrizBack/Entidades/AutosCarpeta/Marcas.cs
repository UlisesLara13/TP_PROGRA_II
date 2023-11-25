using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Marcas
    {

        public int MarcaId { get; set; }
        public string Marca { get; set; }

        public Marcas()
        {
            MarcaId = 0;
            Marca = string.Empty;
        }

        public Marcas(string marca)
        {
            Marca = marca;
        }

        public Marcas(int id, string? marca)
        {
            this.MarcaId = id;
            Marca = marca;
        }

        public override string ToString()
        {
            return Marca;
        }
    }
}
