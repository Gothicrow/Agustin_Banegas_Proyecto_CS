using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebAppSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuario> usuarios()
        {
            return UsuarioNegocio.GetUsuarios().ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            try { 
                Usuario usuario = UsuarioNegocio.GetUsuario(id);
                return Ok(usuario);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(Name = "CreateUsuario")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                Usuario newUsuario = UsuarioNegocio.PostUsuario(usuario.Nombre, usuario.Apellido, usuario.NombreUsuario, usuario.Password, usuario.Email);
                return Ok(newUsuario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut(Name = "UpdateUsuario")]
        public void Put([FromBody] Usuario usuario)
        {
            UsuarioNegocio.UpdateUsuario(usuario.Id, usuario.Nombre, usuario.Apellido, usuario.NombreUsuario, usuario.Password, usuario.Email);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UsuarioNegocio.DeleteUsuario(id);
        }
    }
}
