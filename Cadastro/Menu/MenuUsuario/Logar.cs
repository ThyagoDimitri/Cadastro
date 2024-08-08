using Cadastro.Banco;
using Cadastro;
using System;

public class Logar
{
    private UsuarioDAL dal;

    public Logar()
    {
        dal = new UsuarioDAL();
    }

    public void LogarUsuario()
    {
        Console.WriteLine("Digite o login da conta que deseja acessar: ");
        string login = Console.ReadLine();

        Console.WriteLine("Digite a senha do usuário: ");
        string senha = Console.ReadLine();

        Users loginoNovo = new Users(null, login, senha);

        bool loginSucesso = dal.VerificarLogin(loginoNovo);

        if (loginSucesso)
        {
            Console.WriteLine("Login bem-sucedido!");

            // Obtenha o Id do usuário após o login bem-sucedido
            int usuarioId = dal.ObterUsuarioId(login, senha);
            if (usuarioId == -1)
            {
                Console.WriteLine("Não foi possível encontrar o ID do usuário.");
                return;
            }

            // Crie uma instância de PListaDeTarefa com o ID do usuário
            PListaDeTarefa listaDeTarefas = new PListaDeTarefa(null, null, usuarioId);

            // Carregue as tarefas e exiba o menu de tarefas
            listaDeTarefas.CarregarTarefasDoBanco(usuarioId);
            PListaDeTarefa.ExibirOpcoesDoMenuTarefa(listaDeTarefas);
        }
        else
        {
            Console.WriteLine("Login falhou. Verifique seu login e senha.");
        }
    }
}