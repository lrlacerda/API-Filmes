using System.ComponentModel.DataAnnotations;

namespace WebAPI.Fime.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Filme
    /// </summary
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        public string?  Titulo { get; set; }
        public int IdGenero { get; set; }

        //referência para a classe Genero
        public  GeneroDomain? Genero { get; set; }
    }
}
