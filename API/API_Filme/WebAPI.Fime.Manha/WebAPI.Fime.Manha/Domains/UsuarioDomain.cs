namespace WebAPI.Fime.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Usuarios
    /// </summary
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}


