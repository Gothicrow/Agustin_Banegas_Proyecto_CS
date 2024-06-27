using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebAppSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductosVendidos")]
        public IEnumerable<ProductoVendido> productosVendidos()
        {
            return ProductoVendidoNegocio.GetProductosVendidos().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult GetProductoVendidoById(int id)
        {
            try
            {
                ProductoVendido productoVendido = ProductoVendidoNegocio.GetProductoVendido(id);
                return Ok(productoVendido);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(Name = "CreateProductoVendido")]
        public void Post([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoNegocio.PostProductoVendido(productoVendido.Stock, productoVendido.IdProducto, productoVendido.IdVenta);
        }
        [HttpPut(Name = "UpdateProductoVendido")]
        public void Put([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoNegocio.UpdateProductoVendido(productoVendido.Id, productoVendido.Stock, productoVendido.IdProducto, productoVendido.IdVenta);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductoVendidoNegocio.DeleteProductoVendido(id);
        }
    }
}
