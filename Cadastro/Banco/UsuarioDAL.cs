using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Banco
{
    internal class UsuarioDAL
    {
        public void RegistrarUsuario(Users lista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();
            string sql = "INSERT INTO Usuario (Nome, ULogin, Senha) VALUES (@nome, @uLogin, @senha)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nome", lista.Nome);
            command.Parameters.AddWithValue("@uLogin", lista.LoginUsers);
            command.Parameters.AddWithValue("@senha", lista.Password);

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }


        public bool VerificarLogin(Users lista)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();
            string sql = "SELECT COUNT(*) FROM Usuario WHERE ULogin = @uLogin AND Senha = @senha";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@uLogin", lista.LoginUsers);
            command.Parameters.AddWithValue("@senha", lista.Password);

            int count = (int)command.ExecuteScalar();

           return count > 0;


        }

        public int ObterUsuarioId(string login, string senha)
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();
            string sql = "SELECT IdUsuario FROM Usuario WHERE ULogin = @uLogin AND Senha = @senha";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@uLogin", login);
            command.Parameters.AddWithValue("@senha", senha);

            var result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }


    }
}
