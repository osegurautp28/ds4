using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using InventarioOGFIT.Data;
using InventarioOGFIT.Models;

namespace Inventario.Api.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private readonly DbInventario _db = new DbInventario();

        // GET: https://localhost:PUERTO/api/productos
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<ProductoDto> data = _db.Productos_Listar();

                return Ok(new ApiResponse<List<ProductoDto>>
                {
                    Result = 1,
                    Data = data,
                    Message = "Productos obtenidos correctamente."
                });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ApiResponse<object>
                {
                    Result = 0,
                    Data = null,
                    Message = "Ocurrió un error: " + ex.Message
                });
            }
        }

        // GET: https://localhost:PUERTO/api/productos/2
        [HttpGet, Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                ProductoDto p = _db.Productos_ObtenerPorId(id);

                if (p == null)
                {
                    return Content(HttpStatusCode.NotFound, new ApiResponse<object>
                    {
                        Result = 0,
                        Data = null,
                        Message = "Producto no encontrado."
                    });
                }

                return Ok(new ApiResponse<ProductoDto>
                {
                    Result = 1,
                    Data = p,
                    Message = "Producto obtenido correctamente."
                });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new ApiResponse<object>
                {
                    Result = 0,
                    Data = null,
                    Message = "Ocurrió un error: " + ex.Message
                });
            }
        }
    }
}

