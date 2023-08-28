using WebAPI.Fime.Manha.Domains;

namespace WebAPI.Fime.Manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {

        /// <summary>
        /// Cadastrar um Novo Genero
        /// </summary>
        /// <param name="novoGenero">objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atuslizar um objeto existente passandoseu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objetocom atualizado</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar obejeto esistente passando seu id pela URL
        /// </summary>
        /// <param name="id">id do objeto que será atualizado</param>
        /// <param name="genero">objeto com os novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

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
        GeneroDomain BuscarPorId(int Id);
    }
}
