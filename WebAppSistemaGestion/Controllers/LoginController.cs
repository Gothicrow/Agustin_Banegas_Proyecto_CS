using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebAppSistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost(Name = "LoginUsuario")]
        public IActionResult LoginUsuario(Usuario login)
        {
            try
            {
                Usuario usuario = UsuarioNegocio.LoginUsuario(login);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
