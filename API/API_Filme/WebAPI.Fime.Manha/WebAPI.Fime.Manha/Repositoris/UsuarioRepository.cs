using System.Data.SqlClient;
using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;

namespace WebAPI.Fime.Manha.Repositoris
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados ...
        /// Data Source: Nome do servidor
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação: User Id=sa; Password=Senai@134;
        /// </summary>
        private string StringConexao = "Data Source=NOTE06-S15; Initial Catalog=Filmes_Lucas; User Id=sa; Password=Senai@134;";

        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdUsuario, Email, Permissao FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    {
                        if (rdr.Read())
                        {
                            UsuarioDomain usuario = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = Convert.ToString(rdr["Email"]),
                                Permissao = Convert.ToString(rdr["Permissao"]),
                            };

                            return usuario;
                        }
                        else
                        {
                            return null; // Usuário não encontrado
                        }
                    }
                }
            }
        }
    }

}
