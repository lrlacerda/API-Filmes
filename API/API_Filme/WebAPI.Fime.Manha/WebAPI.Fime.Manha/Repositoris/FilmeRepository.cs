using System.Data.SqlClient;
using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;

namespace WebAPI.Fime.Manha.Repositoris
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados ...
        /// Data Source: Nome do servidor
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação: User Id=sa; Password=Senai@134;
        /// </summary>
        private string StringConexao = "Data Source=NOTE06-S15; Initial Catalog=Filmes_Lucas; User Id=sa; Password=Senai@134;";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Id", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int Id)
        {
            FilmeDomain? filme = null;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = Convert.ToString(rdr["Titulo"])
                        };
                    }
                }
            }

            return filme;
        }


        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(Titulo) VALUES (@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Titulo FROM Filme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = Convert.ToString(rdr["Titulo"])
                        };

                        listaFilmes.Add(filme);
                    }
                }
            }

            return listaFilmes;
        }

    }
}
