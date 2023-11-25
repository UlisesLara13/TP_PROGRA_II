using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomotrizFront.Servicios.Interfaz;

namespace AutomotrizFront.Servicios.Implementacion
{
    public class FabricaServicios : IFabricaServicios
    {
        public IServicio CrearServicio()
        {
            return new Servicio();
        }
    }
}
