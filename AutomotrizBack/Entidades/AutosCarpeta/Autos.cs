using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutosCarpeta
{
    public class Autos
    {
        public int AutoId { get; set; }
        public int Año { get; set; }
        public decimal Capacidad { get; set; }
        public int NroPuertas { get; set; }
        public int NroCiliendros { get; set; }
        public Modelos Modelo { get; set; }
        public Colores Color { get; set; }
        public Tipos_Motor Motor { get; set; }
        public Tipo_Transmision Transmision { get; set; }
        public Tipos_Combustible Combustible { get; set; }
        public Marcas Marca { get; set; }
        public Tipos Tipo { get; set; }
        public float PrecioUnitario { get; set; }

        public Autos()
        {
            AutoId = 0;
            Año = 0;
            Capacidad = 0;
            NroPuertas = 0;
            NroCiliendros = 0;
            Modelo = new Modelos();
            Transmision = new Tipo_Transmision();
            Combustible = new Tipos_Combustible();
            Marca = new Marcas();
            Tipo = new Tipos();
            Color = new Colores();
            Motor = new Tipos_Motor();
            PrecioUnitario = 0;

        }

        public Autos(int id, int año, decimal capacidad, int nropuertas, int nrocilindros, Modelos modelo, Colores color, Tipos_Motor motor, Tipo_Transmision transmision, Tipos_Combustible combustible, Marcas marca, Tipos tipo, float precio)
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

        }

        public override string ToString()
        {
            return Marca.ToString() + " " + Modelo.ToString() + " " + Año;
        }

    }
}
