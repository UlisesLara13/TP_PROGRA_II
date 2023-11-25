using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Fachada.Implementaciones;
using AutomotrizBack.Fachada.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutomotrizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private IAplicacion app;

        public AutoController()
        {
            app = new Aplicacion();
        }

        [HttpGet("/autos")]
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

        [HttpGet("/autos/modelos")]
        public IActionResult GetModelos()
        {
            List<Modelos> lst = null;
            try
            {
                lst = app.GetModelos();
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

        [HttpGet("/autos/marcas")]
        public IActionResult GetMarcas()
        {
            List<Marcas> lst = null;
            try
            {
                lst = app.GetMarcas();
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


        [HttpGet("/autos/combustibles")]
        public IActionResult GetCombuestibles()
        {
            List<Tipos_Combustible> lst = null;
            try
            {
                lst = app.GetCombustible();
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

        [HttpGet("/autos/colores")]
        public IActionResult GetColores()
        {
            List<Colores> lst = null;
            try
            {
                lst = app.GetColores();
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

        [HttpGet("/autos/transmision")]
        public IActionResult GetTipoTransmision()
        {
            List<Tipo_Transmision> lst = null;
            try
            {
                lst = app.GetTransmision();
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

        [HttpGet("/autos/tipos")]
        public IActionResult GetTipos()
        {
            List<Tipos> lst = null;
            try
            {
                lst = app.GetTipos();
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

        


        // GET /autos/tipo-motor
        [HttpGet("/autos/motores")]
        public IActionResult GetTipoMotor()
        {
            List<Tipos_Motor> lst = null;
            try
            {
                lst = app.GetMotores();
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


        [HttpPost("/autos")]
        public IActionResult PostAuto(Autos oAuto)
        {
            try
            {
                if (oAuto == null)
                    return BadRequest("Auto inválido");
                if (app.SaveAuto(oAuto))
                    return Ok(oAuto);
                else
                    return NotFound("No se pudo guardar el auto.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpPut("/autos/actualizar")]
        public IActionResult PutAuto([FromBody] Autos oAuto)
        {
            try
            {
                if (oAuto == null)
                    return BadRequest("Auto inválido");
                if (app.UpdateAuto(oAuto))
                    return Ok(oAuto);
                else
                    return NotFound("No se pudo actualizar el auto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }

        [HttpDelete("/autos/eliminar/{id}")]
        public IActionResult DeleteAuto(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Auto inválido");
                if (app.DeleteAuto(id))
                    return Ok(id);
                else
                    return NotFound("No se pudo eliminar el auto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno. Intente luego.");
            }
        }
    }
}
