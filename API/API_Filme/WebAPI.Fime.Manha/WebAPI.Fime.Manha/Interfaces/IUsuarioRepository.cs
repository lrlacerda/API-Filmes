using WebAPI.Fime.Manha.Domains;

namespace WebAPI.Fime.Manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    ///  Definir os métodos que serão implementados pelo UsuarioRepository
    /// </summary>
    public interface IUsuarioRepository
    {
        bool Login(string Email, string Senha);
        List<UsuarioDomain> ListarTodos();
    }
}


