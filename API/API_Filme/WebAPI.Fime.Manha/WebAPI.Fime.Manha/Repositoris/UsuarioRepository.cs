using WebAPI.Fime.Manha.Domains;
using WebAPI.Fime.Manha.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Fime.Manha.Repositories
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

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdUsuario, Email, Senha, Permissao FROM Usuario";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = Convert.ToString(rdr["Email"]),
                            Senha = Convert.ToString(rdr["Senha"]),
                            Permissao = Convert.ToString(rdr["Permissao"])
                        };

                        listaUsuarios.Add(usuario);
                    }
                }
            }

            return listaUsuarios;
        }

        // Implementação do método Login
        public bool Login(string Email, string Senha)
        {
            // Procurar o usuário com o email fornecido na lista de usuários
            UsuarioDomain usuario = ListarTodos().Find(u => u.Email == Email);

            // Verificar se o usuário foi encontrado e se a senha corresponde
            if (usuario != null && usuario.Senha == Senha)
            {
                return true;  // Login bem-sucedido
            }

            return false;  // Login falhou
        }
    }
}
