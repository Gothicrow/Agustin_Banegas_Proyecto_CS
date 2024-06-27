using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebAppSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> productos()
        {
            return ProductoNegocio.GetProductos().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult GetProductoById(int id)
        {
            try
            {
                Producto producto = ProductoNegocio.GetProducto(id);
                return Ok(producto);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpPost(Name = "CreateProducto")]
        public void Post([FromBody] Producto producto)
        {
            ProductoNegocio.PostProducto(producto.Descripcion, producto.Costo, producto.PrecioVenta, producto.Stock, producto.IdUsuario);
        }
        [HttpPut(Name = "UpdateProducto")]
        public void Put([FromBody] Producto producto)
        {
            ProductoNegocio.UpdateProducto(producto.Id, producto.Descripcion, producto.Costo, producto.PrecioVenta, producto.Stock, producto.IdUsuario);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductoNegocio.DeleteProducto(id);
        }
    }
}
