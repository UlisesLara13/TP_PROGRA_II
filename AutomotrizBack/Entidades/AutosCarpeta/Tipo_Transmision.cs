using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Tipo_Transmision
    {
        public int TipoTransmisionId { get; set; }
        public string TipoTransmision { get; set; }

        public Tipo_Transmision()
        {
            TipoTransmisionId = 0;
            TipoTransmision = string.Empty;
        }

        public Tipo_Transmision(string tipotransmision,int id)
        {
            TipoTransmision = tipotransmision;
            TipoTransmisionId = id;
        }

        public override string ToString() { return TipoTransmision; }
    }
}
