using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebAppSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public IEnumerable<Venta> ventas()
        {
            return VentaNegocio.GetVentas().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult GetVentaById(int id)
        {
            try
            {
                Venta venta = VentaNegocio.GetVenta(id);
                return Ok(venta);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(Name = "CreateVenta")]
        public void Post([FromBody] Venta venta)
        {
            VentaNegocio.PostVenta(venta.Comentarios, venta.IdUsuario);
        }
        [HttpPut(Name = "UpdateVenta")]
        public void Put([FromBody] Venta venta)
        {
            VentaNegocio.UpdateVenta(venta.Id, venta.Comentarios, venta.IdUsuario);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            VentaNegocio.DeleteVenta(id);
        }
    }
}
