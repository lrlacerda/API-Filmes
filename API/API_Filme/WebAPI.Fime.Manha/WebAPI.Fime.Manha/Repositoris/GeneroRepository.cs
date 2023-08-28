using System.Data.SqlClient;
using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;

namespace WebAPI.Fime.Manha.Repositoris
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados ...
        /// Data Source: Nome do servidor
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação: User Id=sa; Password=Senai@134;
        /// </summary>
        private string StringConexao = "Data Source=NOTE06-S15; Initial Catalog=Filmes_Lucas; User Id=sa; Password=Senai@134;";

        /// <summary>
        /// Atualizar IdCorpo
        /// </summary>
        /// <param name="genero">Objeto que será atualizado</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Id", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualizar por IdUrl
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Buscar um gênero atravéz do seu ID
        /// </summary>
        /// <param name="Id">ID do gênero a ser buscado</param>
        /// <returns>objeto buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int Id)
        {
            // Declarando o objeto GeneroDomain para armazenar o resultado
            GeneroDomain genero = null;

            // Declarando a SqlConnection usando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declarando a consulta para recuperar o gênero pelo seu Id
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                // Abrindo a conexão com o banco de dados
                con.Open();

                // Declarando o SqlDataReader para ler os resultados
                SqlDataReader rdr;

                // Declarando o SqlCommand com a consulta e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Adicionando o parâmetro para o Id
                    cmd.Parameters.AddWithValue("@IdGenero", Id);

                    // Executando a consulta e armazenando o resultado no rdr
                    rdr = cmd.ExecuteReader();

                    // Verificando se algum dado foi retornado
                    if (rdr.Read())
                    {
                        // Criando um novo objeto GeneroDomain e preenchendo suas propriedades
                        genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = Convert.ToString(rdr["Nome"])
                        };
                    }
                }
            }

            // Retornando o objeto GeneroDomain encontrado, ou null se não encontrado
            return genero;
        }

        /// <summary>
        /// Cadastrar um novo Gênero
        /// </summary>
        /// <param name="novoGenero">Obejeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //declarar a query que ser[a executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)"; //@cria uma variavél dentro do sql

                //Declara o sqlCommand passando a query que será executada e a conexão com o banco
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um Gênero
        /// </summary>
        /// <param name="Id">Obejeto com as informações que serão deletadas</param>
        public void Deletar(int Id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @Id";

                //Declara o sqlCommand passando a query que será executada e a conexão com o banco
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor do parâmetro @Id
                    cmd.Parameters.AddWithValue("@Id", Id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query (queryDelete)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos generos
        /// </summary>
        /// <returns>Lista de Objetos(gêneros)</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de obejtos do tipo gênero
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexção com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGegero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]), // pode ser assim: IdGenero = Convert.ToInt32(rdr[IdGenero])

                            //Atribui a propriedade nome o valor recebido rdr
                            Nome = Convert.ToString(rdr["Nome"])
                        };

                        //Adiciona cada objeto dentro da lista
                        listaGeneros.Add(genero);

                    }
                }
            }
            //Retorna a lista de Gêneros
            return listaGeneros;
        }
    }
}
