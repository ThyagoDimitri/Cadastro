using Cadastro;

public class AdicionarTarefa
{
    private ListaDeTarefasDAL dal;
    private int usuarioId;

    public AdicionarTarefa(List<PListaDeTarefa> tarefas, int usuarioId)
    {
        this.dal = new ListaDeTarefasDAL();
        this.usuarioId = usuarioId;
    }

    public void AdicionarAListaDeTarefas()
    {
        Console.Write("Digite o nome da tarefa: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a importância da tarefa: ");
        string importancia = Console.ReadLine();

        PListaDeTarefa novaTarefa = new PListaDeTarefa(nome, importancia, usuarioId);

        // Adiciona a nova tarefa no banco de dados
        dal.Adicionar(novaTarefa);

        Console.WriteLine("Tarefa adicionada com sucesso!");
    }
}