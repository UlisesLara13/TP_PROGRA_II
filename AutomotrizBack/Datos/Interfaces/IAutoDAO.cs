using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.Facturas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizBack.Datos.Interfaces
{
    public interface IAutoDAO
    {
        List<AutosAPI> ObtenerAutos();
        List<Modelos> ObtenerModelos();

        List<Colores> ObtenerColores();

        List<Marcas> ObtenerMarcas();

        List<Tipo_Transmision> ObtenerTransmisiones();

        List<Tipos_Combustible> ObtenerCombustible();

        List<Tipos_Motor> ObtenerMotores();
        List<Tipos> ObtenerTipos();

        DataTable ObtenerConsultasParametros(string sp, List<Parametro> parametros);

        bool CrearAuto(Autos oAuto);

        bool EliminarAuto(int id);

        bool ActualizarAuto(Autos oAuto);

        DataTable ObtenerPorEscalar(string nombreSP, int valorParametro);

        int ObtenerProximoAuto();

        DataTable ObtenerConsulta(string sp);
        List<Autos> ObtenerAutosCbo();


    }
}
