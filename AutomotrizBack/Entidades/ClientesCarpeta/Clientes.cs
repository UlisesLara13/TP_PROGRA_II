using AutomotrizBack.Entidades.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.ClientesCarpeta
{
    public class Clientes
    {
        public int ClienteId { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int CuitCuil{ get; set; }
        public Barrios Barrio { get; set; }
        public Tipos_Cliente Tipo { get; set; }

        public Contactos Contactos { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            RazonSocial = string.Empty;
            Calle = string.Empty;
            Altura = 0;
            CuitCuil = 0;
            Barrio = new Barrios();
            Tipo = new Tipos_Cliente();
            Contactos = new Contactos();

        }

        public Clientes(int id,string razonsocial, string calle, int altura, int cuitcuil, Barrios barrio, Tipos_Cliente tipo,Contactos contactos)
        {
            ClienteId = id;
            RazonSocial = razonsocial;
            Calle = calle;
            Altura = altura;
            CuitCuil = cuitcuil;
            Barrio = barrio;
            Tipo = tipo;
            Contactos = contactos;
        }


        public override string ToString()
        {
            return RazonSocial + "|Cuit/Cuil: " + CuitCuil;
        }
    }
}
