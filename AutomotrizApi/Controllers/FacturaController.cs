using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using AutomotrizBack.Fachada.Implementaciones;
using AutomotrizBack.Fachada.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomotrizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IAplicacion app;

        public FacturaController()
        {
            app = new Aplicacion();
        }


        [HttpGet("/facturas")]
        public IActionResult GetFacturas()
        {
            List<Factura_AutosAPI> lst = null;
            try
            {
                lst = app.GetFacturas();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpGet("/facturas/{id}")]
        public IActionResult GetFactura(int id)
        {
            Factura_Autos lst = null;
            try
            {
                lst = app.GetFactura(id);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpGet("/facturas/autos")]
        public IActionResult GetAutos()
        {
            List<AutosAPI> lst = null;
            try
            {
                lst = app.GetAutos();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpGet("/facturas/clientes")]
        public IActionResult GetClientes()
        {
            List<ClientesAPI> lst = null;
            try
            {
                lst = app.GetClientes();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                var error = ex.InnerException;

                if (error is SqlException)
                {
                    // El error es causado por un error de SQL
                    var sqlException = (SqlException)error;
                    return StatusCode(500, sqlException.Message);
                }
                else
                {
                    // El error es causado por otra causa
                    return StatusCode(500, "Error interno. Intente luego.");
                }
            }
        }

        [HttpGet("/facturas/envios")]
        public IActionResult GetEnvios()
        {
            List<Forma_Envio> lst = null;
            try
            {
                lst = app.GetEnvios();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpGet("/facturas/pagos")]
        public IActionResult GetPagos()
        {
            List<Forma_Pago> lst = null;
            try
            {
                lst = app.GetPagos();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }


        [HttpPost("/facturas")]
        public IActionResult PostFactura(Factura_Autos oFactura)
        {
            try
            {
                if (oFactura == null)
                    return BadRequest("Factura inválida");
                if (app.SaveFactura(oFactura))
                    return Ok(oFactura);
                else
                    return NotFound("No se pudo guardar la factura.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }



        [HttpPut("/facturas/actualizar")]
        public IActionResult PutFactura([FromBody] Factura_Autos oFactura)
        {
            try
            {
                if (oFactura == null)
                    return BadRequest("Factura inválida");
                if (app.UpdateFactura(oFactura))
                    return Ok(oFactura);
                else
                    return NotFound("No se pudo actualizar la factura");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpDelete("/facturas/eliminar/{id}")]
        public IActionResult DeleteFactura(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Factura inválida");
                if (app.DeleteFactura(id))
                    return Ok(id);
                else
                    return NotFound("No se pudo eliminar la factura");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpDelete("/facturas/eliminar/detalle/{id}")]
        public IActionResult DeleteDetalle(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Detalle inválido");
                if (app.DeleteDetalle(id))
                    return Ok(id);
                else
                    return NotFound("No se pudo eliminar el detalle");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }


    }
}
