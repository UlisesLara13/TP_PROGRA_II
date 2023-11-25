using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Entidades.AutopartesCarpeta
{
    public class Autopartes
    {
        public int AutoparteId { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string Descripcion { get; set; }
        public float PrecioUnitario { get; set; }
        public Tipo_Autopartes Tipo { get; set; }
        public Modelo_Autopartes Modelo { get; set; }

        public Autopartes()
        {
            AutoparteId = 0;
            Stock = 0;
            StockMinimo = 0;
            Descripcion = string.Empty;
            PrecioUnitario = 0;
            Tipo = new Tipo_Autopartes();
            Modelo = new Modelo_Autopartes();
        }

        public Autopartes(int stock, int stockminimo, string descripcion, float preciounitario, Tipo_Autopartes tipo, Modelo_Autopartes modelo)
        {
            Stock = stock;
            StockMinimo = stockminimo;
            Descripcion = descripcion;
            PrecioUnitario = preciounitario;
            Tipo = tipo;
            Modelo = modelo;
        }

        public override string ToString()
        {
            return Descripcion + " |Precio Unitario: " + PrecioUnitario + " |Tipo: " + Tipo + " |Modelo: " + Modelo;
        }
    }
}
