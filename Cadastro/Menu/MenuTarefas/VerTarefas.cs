using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Menu.MenuTarefas
{
    internal class VerTarefas
    {
        private List<PListaDeTarefa> tarefas;

        public VerTarefas(List<PListaDeTarefa> tarefas)
        {
            this.tarefas = tarefas;
        }

        public void VerListaDeTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("A lista de tarefas está vazia.");
                return;
            }

            Console.WriteLine("Tarefas na lista:");
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"ID: {tarefa.Id}, Tarefa: {tarefa.NomeTarefa}, Importância: {tarefa.ImportanciaDaTarefa}");
            }
        }
    }
}
