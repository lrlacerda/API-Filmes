using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;
using WebAPI.Fime.Manha.Repositoris;

namespace WebAPI.Fime.Manha.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    //Define que tipo de resposta da api será no formato json
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController() 
        {
            _filmeRepository = new FilmeRepository();
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
                List<FilmeDomain> listaFilme = _filmeRepository.ListarTodos();

                //Retorna a lista no formato json com o estatus code ok(200)
                return Ok(listaFilme);
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
                FilmeDomain genero = _filmeRepository.BuscarPorId(id);

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
        public IActionResult Post(FilmeDomain nonoFilme)
        {
            try
            {
                //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
                _filmeRepository.Cadastrar(nonoFilme);

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
                _filmeRepository.Deletar(id);

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
        /// Atualizar um determinado Filme pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filme"></param>
        /// <returns>O objeto atualizado</returns>
        [HttpPut("{id}")] // Use o atributo HttpPut e especifique o parâmetro id
        public IActionResult Put(int id, FilmeDomain filme) // Especifique os parâmetros id e Filme
        {
            try
            {
                // Chame o método BuscarPorId do repositório para verificar se o gênero existe
                FilmeDomain filmeExistente = _filmeRepository.BuscarPorId(id);

                if (filmeExistente == null)
                {
                    // Retorna o status code 404 - Not Found se o filme não for encontrado
                    return NotFound();
                }

                // Atribua o id do gênero existente ao objeto recebido
                filme.IdFilme = id;

                // Chame o método AtualizarIdUrl do repositório para atualizar o gênero
                _filmeRepository.AtualizarIdUrl(id, filme);

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
        public IActionResult Put(FilmeDomain filme)
        {
            try
            {
                // Verifique se o filme existe no repositório
                FilmeDomain filmeExistente = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeExistente == null)
                {
                    // Retorna o status code 404 - Not Found se o filme não for encontrado
                    return NotFound();
                }

                // Chame o método AtualizarIdCorpo do repositório para atualizar o gênero
                _filmeRepository.AtualizarIdCorpo(filme);

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
