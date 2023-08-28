using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;

namespace WebAPI.Fime.Manha.Repositoris
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados ...
        /// </summary>
        private string StringConexao = "Data Source=NOTE06-S15; Initial Catalog=Filmes_Lucas; User Id=sa; Password=Senai@134;";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int Id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
