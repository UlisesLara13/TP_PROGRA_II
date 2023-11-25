using AutomotrizBack.Datos;
using AutomotrizBack.Datos.Implementaciones;
using AutomotrizBack.Datos.Interfaces;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using AutomotrizBack.Fachada.Interfaces;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Fachada.Implementaciones
{
    public class Aplicacion : IAplicacion
    {

        private IAutoDAO autoDAO;
        private IFacturaAutoDAO facturaDAO;
        public Aplicacion()
        {
            autoDAO = new AutoDAO();
            facturaDAO = new FacturaAutoDAO();
        }
        public bool DeleteAuto(int id)
        {
            return autoDAO.EliminarAuto(id);
        }

        public bool DeleteFactura(int id)
        {
            return facturaDAO.Eliminar_FacturaAuto(id);
        }

        public bool DeleteDetalle(int id) 
        {
            return facturaDAO.Eliminar_Detalle(id);
        }

        public List<AutosAPI> GetAutos()
        {
            return autoDAO.ObtenerAutos();
        }

        public List<Colores> GetColores()
        {
            return autoDAO.ObtenerColores();
        }

        public List<Factura_AutosAPI> GetFacturas()
        {
            return facturaDAO.ObtenerFacturaAuto();
        }

        public Factura_Autos GetFactura(int numero)
        {
            return facturaDAO.ObtenerFacturaAutoNro(numero);
        }


        public List<Marcas> GetMarcas()
        {
            return autoDAO.ObtenerMarcas();
        }

        public List<Modelos> GetModelos()
        {
            return autoDAO.ObtenerModelos();
        }

        public List<Tipo_Transmision> GetTransmision()
        {
            return autoDAO.ObtenerTransmisiones();
        }

        public bool SaveAuto(Autos oAuto)
        {
            return autoDAO.CrearAuto(oAuto);
        }

        public bool SaveFactura(Factura_Autos oFactura)
        {
            return facturaDAO.Crear(oFactura);
        }

        public bool UpdateAuto(Autos oAutos)
        {
            return autoDAO.ActualizarAuto(oAutos);
        }

        public bool Eliminar_FacturaAuto(int nro_factura)
        {
            return facturaDAO.Eliminar_FacturaAuto(nro_factura);
        }

        public bool UpdateFactura(Factura_Autos oFactura)
        {
            return facturaDAO.ActualizarFactura(oFactura);
        }


        public List<Tipos_Motor> GetMotores()
        {
            return autoDAO.ObtenerMotores();
        }

        public List<Tipos> GetTipos()
        {
            return autoDAO.ObtenerTipos();
        }

        public List<Tipos_Combustible> GetCombustible()
        {
            return autoDAO.ObtenerCombustible();
        }

        public List<ClientesAPI> GetClientes()
        {
            return facturaDAO.ObtenerClientes();
        }

        public List<Forma_Envio> GetEnvios()
        {
            return facturaDAO.ObtenerFormaEnvio();
        }

        public List<Forma_Pago> GetPagos()
        {
            return facturaDAO.ObtenerFormaPago();
        }

        

       
    }
}
