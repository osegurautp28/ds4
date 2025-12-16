using System.Net;
using System.Web.Http;
using InventarioOGFIT.Data;
using InventarioOGFIT.Models;
using System;


namespace Inventario.Api.Controllers
{
    [RoutePrefix("api/stock")]
    public class StockController : ApiController
    {
        private readonly DbInventario _db = new DbInventario();

        // POST: https://localhost:PUERTO/api/stock/entrada
        [HttpPost, Route("entrada")]
        public IHttpActionResult Entrada([FromBody] MovimientoRequest req)
        {
            if (req == null)
                return BadRequest("Body inválido.");

            if (req.ProductoId <= 0 || req.Cantidad <= 0)
                return BadRequest("ProductoId y Cantidad deben ser > 0.");

            try
            {
                _db.Movimientos_Registrar(req.ProductoId, "ENTRADA", req.Cantidad, req.Nota);

                return Ok(new ApiResponse<object>
                {
                    Result = 1,
                    Data = null,
                    Message = "Entrada registrada y stock actualizado."
                });
            }
            catch (Exception ex)
            {
                // Si SP falla (stock insuficiente, etc.) cae aquí
                return Content(HttpStatusCode.BadRequest, new ApiResponse<object>
                {
                    Result = 0,
                    Data = null,
                    Message = "Ocurrió un error: " + ex.Message
                });
            }
        }

        // POST: https://localhost:PUERTO/api/stock/salida
        [HttpPost, Route("salida")]
        public IHttpActionResult Salida([FromBody] MovimientoRequest req)
        {
            if (req == null)
                return BadRequest("Body inválido.");

            if (req.ProductoId <= 0 || req.Cantidad <= 0)
                return BadRequest("ProductoId y Cantidad deben ser > 0.");

            try
            {
                _db.Movimientos_Registrar(req.ProductoId, "SALIDA", req.Cantidad, req.Nota);

                return Ok(new ApiResponse<object>
                {
                    Result = 1,
                    Data = null,
                    Message = "Salida registrada y stock actualizado."
                });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ApiResponse<object>
                {
                    Result = 0,
                    Data = null,
                    Message = "Ocurrió un error: " + ex.Message
                });
            }
        }
    }
}

