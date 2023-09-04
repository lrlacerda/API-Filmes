using System.ComponentModel.DataAnnotations;

namespace WebAPI.Fime.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage ="O Campo Email é Obrigatório")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength =3, ErrorMessage ="A senha deve ter de 3 à 20 caracteres")]
        [Required(ErrorMessage ="O campo Senha é Obrigatório")]
        public string Senha { get; set; }
        public string Permissao { get; set; }

        //public UsuarioDomain Usuario { get; set; }
    }
}


