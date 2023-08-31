using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;
using WebAPI.Fime.Manha.Repositoris;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Fime.Manha.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //dominio/api/nomeController
    //ex. http://localhost:500/api/genero
    [Route("api/[controller]")]

    //Define que é um controlador de api
    [ApiController]

    //Define que tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será gerado os Endpoints (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método ListarTodos no repositório e retorna a resposta para o usuário(front-end)
        /// </summary>
        /// <returns>Retorna a resposnta para o usuário</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição
                List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();

                //Retorna a lista no formato json com o estatus code ok(200)
                return Ok(listaGenero);
            }
            catch (Exception erro)
            {
                //Retorna o status code BadRequest(400) e a mensagem de erro
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// Endpoint que aciona o método ListarId no repositório e retorna a resposta para o usuário(front-end)
        /// </summary>
        /// <returns>Retorna a resposnta para o usuário</returns>
        [HttpGet("{id}")] // Use o atributo HttpGet e especifique o parâmetro id
        public IActionResult Get(int id) // Especifique o parâmetro id no método
        {
            try
            {
                // Chama o método BuscarPorId do repositório, passando o id como parâmetro
                GeneroDomain genero = _generoRepository.BuscarPorId(id);

                if (genero == null)
                {
                    // Retorna o status code 404 - Not Found se o gênero não for encontrado
                    return NotFound();
                }

                // Retorna o gênero encontrado no formato json com o status code 200 - OK
                return Ok(genero);
            }
            catch (Exception erro)
            {
                // Retorna o status code 500 - Internal Server Error e a mensagem de erro
                return StatusCode(500, erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastro gênero
        /// </summary>
        /// <param name="nonoGenero">Objeto recebido na requisição</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain nonoGenero)
        {
            try
            {
                //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
                _generoRepository.Cadastrar(nonoGenero);

                //Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400(badRequest) e a mensagem de 
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deletar um determinado Gênero
        /// </summary>
        /// <param name="id">ID do Objeto recebido na requisição a ser Deletado</param>
        [HttpDelete("{id}")] // Use o atributo HttpDelete e especifique o parâmetro id
        public IActionResult Delete(int id) // Especifique o parâmetro id no método
        {
            try
            {
                // Chama o método de exclusão do repositório
                _generoRepository.Deletar(id);

                // Retorna o status code 204 - No Content para indicar a exclusão bem-sucedida
                return NoContent(); //ou return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna o status code 500 - Internal Server Error e a mensagem de erro
                return StatusCode(500, erro.Message);
            }
        }

        /// <summary>
        /// Atualizar um determinado Gênero pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut("{id}")] // Use o atributo HttpPut e especifique o parâmetro id
        public IActionResult Put(int id, GeneroDomain genero) // Especifique os parâmetros id e genero
        {
            try
            {
                // Chame o método BuscarPorId do repositório para verificar se o gênero existe
                GeneroDomain generoExistente = _generoRepository.BuscarPorId(id);

                if (generoExistente == null)
                {
                    // Retorna o status code 404 - Not Found se o gênero não for encontrado
                    return NotFound();
                }

                // Atribua o id do gênero existente ao objeto recebido
                genero.IdGenero = id;

                // Chame o método AtualizarIdUrl do repositório para atualizar o gênero
                _generoRepository.AtualizarIdUrl(id, genero);

                // Retorne o status code 204 - No Content para indicar a atualização bem-sucedida
                return NoContent(); // ou return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorne o status code 500 - Internal Server Error e a mensagem de erro
                return StatusCode(500, erro.Message);
            }
        }

        /// <summary>
        /// Atualizar um determinado Gênero pelo Corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut]
        public IActionResult Put(GeneroDomain genero)
        {
            try
            {
                // Verifique se o gênero existe no repositório
                GeneroDomain generoExistente = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoExistente == null)
                {
                    // Retorna o status code 404 - Not Found se o gênero não for encontrado
                    return NotFound();
                }

                // Chame o método AtualizarIdCorpo do repositório para atualizar o gênero
                _generoRepository.AtualizarIdCorpo(genero);

                // Retorne o status code 204 - No Content para indicar a atualização bem-sucedida
                return NoContent();
            }
            catch (Exception erro)
            {
                // Retorne o status code 500 - Internal Server Error e a mensagem de erro
                return StatusCode(500, erro.Message);
            }
        }
    }
}
