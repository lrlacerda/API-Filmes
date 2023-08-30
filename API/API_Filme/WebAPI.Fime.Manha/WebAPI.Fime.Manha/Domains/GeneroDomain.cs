using System.ComponentModel.DataAnnotations;

namespace WebAPI.Fime.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do Gênero é obrigatório")]
        public string? Nome  { get; set; }

    }
}
