using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;
using WebAPI.Fime.Manha.Repositoris;

namespace WebAPI.Fime.Manha.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //dominio/api/nomeController
    //ex. http://localhost:500/api/usuario
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]

    //Define que tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será gerado os Endpoints (rotas)
    public class UsuarioController : ControllerBase
    {
        private  IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(string email, string senha)
        {
            try
            {
                // Verifique se o usuário existe e a senha está correta
                UsuarioDomain user = _usuarioRepository.Login(email, senha);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
                   
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { message = erro.Message });
            }
        }
    }
}

