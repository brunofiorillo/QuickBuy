using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Entidade;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.Email == "bruno@teste.com" && usuario.Senha == "123")
                {
                    return Ok(usuario);
                }
                return BadRequest("Usuario ou senha Invalido");
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
