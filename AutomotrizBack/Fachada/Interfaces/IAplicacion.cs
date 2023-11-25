using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Fachada.Interfaces
{
    public interface IAplicacion
    {
        List<AutosAPI> GetAutos();
        List<Factura_AutosAPI> GetFacturas();
        Factura_Autos GetFactura(int numero);

        List<Modelos> GetModelos();
        List<Colores> GetColores();
        List<Marcas> GetMarcas();
        List<ClientesAPI> GetClientes();
        List<Forma_Envio> GetEnvios();
        List<Forma_Pago> GetPagos();
        List<Tipos_Combustible> GetCombustible();
        List<Tipos_Motor> GetMotores();
        List<Tipos> GetTipos();
        List<Tipo_Transmision> GetTransmision();

        bool SaveAuto(Autos oAuto);
        bool SaveFactura(Factura_Autos oFactura);

        bool DeleteAuto(int id);
        bool DeleteFactura(int id);

        bool DeleteDetalle(int id);

        bool UpdateAuto(Autos oAutos);
        bool UpdateFactura(Factura_Autos oFactura);

        bool Eliminar_FacturaAuto(int nro_factura);

    }
}
