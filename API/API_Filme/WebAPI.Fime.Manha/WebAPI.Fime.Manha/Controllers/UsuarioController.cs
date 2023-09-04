using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            try
            {
                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou Senha Inválidos");
                }

                //CASO ENCONTRE O USUÁRIO, PROSSEGUE PARA A CRIAÇÃO DO TOKEN

                //1 - Definir as informações (Claims) que serão fornecidos no Token (Playload)
                var claims = new[]
                {
                    //Formato da Claim 
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),

                    //Existe a possibilidade de criar uma Claim personalizada
                    new Claim("Claim Personalizada", "Valor da Claim Personalizada")
                };

                //2 - Definir a chave de acesso ao Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3 - Definir as credenciais do Token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - Gerar o Token
                var token = new JwtSecurityToken
                    (
                        //emissor do Token
                        issuer: "WebAPI.Filme.Manha",

                        //destinatário do Token
                        audience: "WebAPI.Filme.Manha",

                        //dados definidos nas Claims(informações)
                        claims: claims,

                        //tempo de expiração do token
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do Token
                        signingCredentials: creds
                    );

                //5 - retornar o Token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

                return Ok();

            }
            catch (Exception erro)
            {
                return StatusCode(500, new { message = erro.Message });
            }
        }
    }
}

