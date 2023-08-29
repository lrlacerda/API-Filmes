using WebAPI.Fime.Manha.Domains;

namespace WebAPI.Fime.Manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// Definir os métodos que serão implementados pelo FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastrar um Novo Genero
        /// </summary>
        /// <param name="novoFilme">objeto que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atuslizar um objeto existente passandoseu id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objetocom atualizado</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar obejeto esistente passando seu id pela URL
        /// </summary>
        /// <param name="id">id do objeto que será atualizado</param>
        /// <param name="filme">objeto com os novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="Id">id do objetoserá deletado</param>
        void Deletar(int Id);

        /// <summary>
        /// Busca um obejto atravez do seu id
        /// </summary>
        /// <param name="Id">id do obejeto a ser buscado</param>
        /// <returns>objeto buscado</returns>
        FilmeDomain BuscarPorId(int Id);
    }
}
