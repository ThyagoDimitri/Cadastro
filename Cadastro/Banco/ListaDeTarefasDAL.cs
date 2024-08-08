using Cadastro.Banco;
using Cadastro;
using Microsoft.Data.SqlClient;

public class ListaDeTarefasDAL
{
    public IEnumerable<PListaDeTarefa> Listar(int usuarioId)
    {
        var lista = new List<PListaDeTarefa>();
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "SELECT * FROM ListaDeTarefasDeCadaUsuario WHERE UsuarioId = @usuarioId";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@usuarioId", usuarioId);
        using SqlDataReader dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            string nomeTarefa = Convert.ToString(dataReader["Nome"]);
            string importanciaDaTarefa = Convert.ToString(dataReader["ImportanciaTarefa"]);
            int idTarefa = Convert.ToInt32(dataReader["IdTarefa"]);
            PListaDeTarefa tarefa = new PListaDeTarefa(nomeTarefa, importanciaDaTarefa, usuarioId) { Id = idTarefa };
            lista.Add(tarefa);
        }
        return lista;
    }

    public void Adicionar(PListaDeTarefa tarefa)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "INSERT INTO ListaDeTarefasDeCadaUsuario (Nome, ImportanciaTarefa, UsuarioId) VALUES (@nome, @importanciaTarefa, @usuarioId)";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", tarefa.NomeTarefa);
        command.Parameters.AddWithValue("@importanciaTarefa", tarefa.ImportanciaDaTarefa);
        command.Parameters.AddWithValue("@usuarioId", tarefa.UsuarioId);
        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }

    public void Remover(PListaDeTarefa tarefa)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            string removeSql = "DELETE FROM ListaDeTarefasDeCadaUsuario WHERE IdTarefa = @Id AND UsuarioId = @UsuarioId";
            SqlCommand removeCommand = new SqlCommand(removeSql, connection, transaction);
            removeCommand.Parameters.AddWithValue("@Id", tarefa.Id);
            removeCommand.Parameters.AddWithValue("@UsuarioId", tarefa.UsuarioId);
            removeCommand.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine($"Tarefa com ID {tarefa.Id} removida com sucesso.");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine($"Erro ao remover tarefa: {ex.Message}");
        }
    }
}