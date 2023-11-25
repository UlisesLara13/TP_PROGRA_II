using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class ClientesAPI
    {
        public int ClienteId { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int CuitCuil { get; set; }
        public string Barrio { get; set; }
        public string Tipo { get; set; }
        public string Contacto { get; set; }

        public string Alias { get; set; }



        public ClientesAPI()
        {
            ClienteId = 0;
            RazonSocial = string.Empty;
            Calle = string.Empty;
            Altura = 0;
            CuitCuil = 0;
            Barrio = string.Empty;
            Tipo = string.Empty;
            Contacto = string.Empty;
            Alias = string.Empty;

        }

        public ClientesAPI(int id, string razonsocial, string calle, int altura, int cuitcuil, string barrio, string tipo, string contactos,string alias)
        {
            ClienteId = id;
            RazonSocial = razonsocial;
            Calle = calle;
            Altura = altura;
            CuitCuil = cuitcuil;
            Barrio = barrio;
            Tipo = tipo;
            Contacto = contactos;
            Alias = alias;
        }

        public override string ToString()
        {
            return $"{RazonSocial} - {CuitCuil}";
        }
    }
}
