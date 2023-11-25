using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class AutosAPI
    {
        public int AutoId { get; set; }
        public int Año { get; set; }
        decimal Capacidad { get; set; }
        public int NroPuertas { get; set; }
        public int NroCiliendros { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Motor { get; set; }
        public string Transmision { get; set; }
        public string Combustible { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        float PrecioUnitario { get; set; }
        public string Alias { get; set; }

        public AutosAPI()
        {
            AutoId = 0;
            Año = 0;
            Capacidad = 0;
            NroPuertas = 0;
            NroCiliendros = 0;
            Modelo = string.Empty;
            Transmision = string.Empty;
            Combustible = string.Empty;
            Marca = string.Empty;
            Tipo = string.Empty;
            Color = string.Empty;
            Motor = string.Empty;
            PrecioUnitario = 0;
            Alias = string.Empty;
        }

        public AutosAPI(int id, int año, decimal capacidad, int nropuertas, int nrocilindros, string modelo, string color, string motor, string transmision, string combustible, string marca, string tipo, float precio,string alias)
        {
            AutoId = id;
            Año = año;
            Capacidad = capacidad;
            NroPuertas = nropuertas;
            NroCiliendros = nrocilindros;
            Modelo = modelo;
            Transmision = transmision;
            Combustible = combustible;
            Marca = marca;
            Tipo = tipo;
            PrecioUnitario = precio;
            Color = color;
            Motor = motor;
            Alias = alias;
        }
    }
}
