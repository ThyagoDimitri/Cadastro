using Cadastro.Banco;
using Cadastro.Menu.MenuTarefas;
using System;
using System.Collections.Generic;

namespace Cadastro
{
    public class PListaDeTarefa
    {
        public string? NomeTarefa { get; private set; }
        public string? ImportanciaDaTarefa { get; private set; }
        public int Id { get; internal set; }
        public int UsuarioId { get; set; } // Novo campo para identificar o usuário

        public List<PListaDeTarefa> Tarefas { get; private set; } = new List<PListaDeTarefa>();
        public List<PListaDeTarefa> TarefasConcluidas { get; private set; } = new List<PListaDeTarefa>();

        public PListaDeTarefa(string? nomeTarefa, string? importanciaDaTarefa, int usuarioId)
        {
            NomeTarefa = nomeTarefa;
            ImportanciaDaTarefa = importanciaDaTarefa;
            UsuarioId = usuarioId;
        }

        public void CarregarTarefasDoBanco(int usuarioId)
        {
            ListaDeTarefasDAL dal = new ListaDeTarefasDAL();
            var tarefasDoBanco = dal.Listar(usuarioId);
            Tarefas.Clear();
            Tarefas.AddRange(tarefasDoBanco);
        }

        public static void ExibirOpcoesDoMenuTarefa(PListaDeTarefa listaDeTarefas)
        {
            AdicionarTarefa adicionarTarefa = new AdicionarTarefa(listaDeTarefas.Tarefas, listaDeTarefas.UsuarioId);
            VerTarefas verTarefas = new VerTarefas(listaDeTarefas.Tarefas);
            RemoverDaListaDeTarefas removerTarefa = new RemoverDaListaDeTarefas(listaDeTarefas.Tarefas);

            while (true)
            {
                Console.WriteLine("Escolha a opção que deseja: ");
                Console.WriteLine("1- Adicionar tarefa");
                Console.WriteLine("2- Ver lista de tarefas");
                Console.WriteLine("3- Remover tarefa");
                Console.WriteLine("4- Sair");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        adicionarTarefa.AdicionarAListaDeTarefas();
                        break;
                    case 2:
                        listaDeTarefas.CarregarTarefasDoBanco(listaDeTarefas.UsuarioId); // Atualizar lista de tarefas
                        verTarefas.VerListaDeTarefas();
                        break;
                    case 3:
                        removerTarefa.RemoverTarefa();
                        break;
                    case 4:
                        return; // Encerra o loop e sai do programa
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }
    }
}