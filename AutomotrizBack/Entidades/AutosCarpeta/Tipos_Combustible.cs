using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Tipos_Combustible
    {
        public int TipoCombustibleID { get; set; }
        public string TipoCombustible { get; set; }

        public Tipos_Combustible()
        {
            TipoCombustibleID = 0;
            TipoCombustible = string.Empty;
        }

        public Tipos_Combustible(string tipocombustible, int id)
        {
            TipoCombustible = tipocombustible;
            TipoCombustibleID = id;
        }

        public override string ToString()
        {
            return TipoCombustible;
        }
    }
}
