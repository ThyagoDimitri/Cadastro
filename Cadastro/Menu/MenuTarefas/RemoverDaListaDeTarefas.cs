using Cadastro.Banco;
using System;
using System.Collections.Generic;

namespace Cadastro.Menu.MenuTarefas
{
    internal class RemoverDaListaDeTarefas
    {
        private List<PListaDeTarefa> tarefas;
        private ListaDeTarefasDAL dal;

        public RemoverDaListaDeTarefas(List<PListaDeTarefa> tarefas)
        {
            this.tarefas = tarefas;
            this.dal = new ListaDeTarefasDAL();
        }

        public void RemoverTarefa()
        {
            Console.WriteLine("Digite o ID da tarefa que gostaria de remover: ");
            string ID = Console.ReadLine();

            // Encontrar a tarefa na lista pelo ID
            PListaDeTarefa tarefaParaRemover = tarefas.Find(t => t.Id == Convert.ToInt32(ID));

            if (tarefaParaRemover != null)
            {
                tarefas.Remove(tarefaParaRemover); // Remover da lista em memória
                dal.Remover(tarefaParaRemover); // Remover do banco de dados

                Console.WriteLine($"Tarefa {ID} removida com sucesso.");
            }
            else
            {
                Console.WriteLine($"Tarefa com ID {ID} não encontrada na lista.");
            }
        }
    }
}